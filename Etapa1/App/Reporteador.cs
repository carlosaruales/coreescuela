using System;
using System.Collections.Generic;
using Etapa1.Entidades;
using System.Linq;

namespace Etapa1.App
{
    public class Reporteador
    {
        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>  dic)
        {
            if (dic == null)
            {
                throw new ArgumentNullException(nameof(dic));
            }
            _diccionario = dic;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones() {
            if (_diccionario.TryGetValue(LlavesDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> lista)) {
                return lista.Cast<Evaluacion>();
            } else {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> olistaEvaluaciones) {
            var listaEvaluaciones = GetListaEvaluaciones();
            olistaEvaluaciones = listaEvaluaciones;

            return  (from ev in listaEvaluaciones
                    // where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();
        }

        public IEnumerable<string> GetListaAsignaturas() {
            return GetListaAsignaturas(
                out var dummy
            );
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionesXAsignatura() {
            var rta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from evaluacion in listaEvaluaciones
                                where evaluacion.Asignatura.Nombre == asig
                                select evaluacion;
                                
                rta.Add(asig, evalsAsig);
            }

            return rta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnosXAsig() {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvXAsig = GetDicEvaluacionesXAsignatura();

            foreach (var asigConEval in dicEvXAsig)
            {
                var promediosAlumnos = from eval in asigConEval.Value
                            group eval by new {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into grupoEvalAlumno
                            select  new AlumnoPromedio{
                                AlumnoId = grupoEvalAlumno.Key.UniqueId,
                                AlumnoNombre = grupoEvalAlumno.Key.Nombre,
                                Promedio = grupoEvalAlumno.Average(evaluacion => evaluacion.Nota)
                            };

                rta.Add(asigConEval.Key, promediosAlumnos);
                
            }
            return rta;
        }
    }
}