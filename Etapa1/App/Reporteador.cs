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

        public IEnumerable<string> GetListaAsignaturas() {
            var listaEvaluaciones = GetListaEvaluaciones();

            return  (from ev in listaEvaluaciones
                    // where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionesXAsignatura() {
            var rta = new Dictionary<string, IEnumerable<Evaluacion>>();

            return rta;
        }
    }
}