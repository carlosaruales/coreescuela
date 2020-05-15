using System;
using System.Collections.Generic;
using Etapa1.Entidades;

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

        public IEnumerable<Escuela> GetListaEvaluaciones() {
            IEnumerable<Escuela> rta;

            if (_diccionario.TryGetValue(LlavesDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> lista)) {
                // rta = lista.Cast<Evaluacion>();
                rta = null;
            } else {
                rta = null;
            }
            return rta;
        }
    }
}