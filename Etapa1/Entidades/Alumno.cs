using System.Collections.Generic;

namespace Etapa1.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public Alumno() => UniqueId = System.Guid.NewGuid().ToString();
        public List<Evaluaciones> Evaluaciones {get; set;}
    }
}