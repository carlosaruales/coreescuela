using System.Collections.Generic;
namespace Etapa1.Entidades
{
    public class Curso: ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignatura {get; set;}
        public List<Alumno> Alumno {get; set;}
    }
}