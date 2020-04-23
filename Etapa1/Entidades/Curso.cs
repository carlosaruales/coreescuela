using System.Collections.Generic;
namespace Etapa1.Entidades
{
    public class Curso
    {
        public Curso() => UniqueId = System.Guid.NewGuid().ToString();
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignatura {get; set;}
        public List<Alumno> Alumno {get; set;}
    }
}