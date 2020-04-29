using System.Collections.Generic;

namespace Etapa1.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones {get; set;} = new List<Evaluacion>();
    }
}