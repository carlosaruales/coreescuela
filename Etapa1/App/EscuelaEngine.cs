using Etapa1.Entidades;
using System.Collections.Generic;

namespace Etapa1.App
{
    public class EscuelaEngine
    {
        public Escuela escuela {get; set;}

        public EscuelaEngine()
        {
            
        }

        public void Inicializar(){
            escuela = new Escuela(
                "Platzi", 
                2012, 
                TiposEscuela.Primaria, 
                ciudad: "Pradera"
            );

            escuela.Cursos = new List<Curso>() {
                new Curso() { Nombre = "101", Jornada= TiposJornada.Afternoon },
                new Curso() { Nombre = "201" },
                new Curso() { Nombre = "301" }
            };
        }
    }
}