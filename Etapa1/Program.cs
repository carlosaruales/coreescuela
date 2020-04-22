using System;
using Etapa1.Entidades;
using static System.Console;
using Etapa1.App;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            ImprimirCursosEscuela(engine.escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela) {
            WriteLine("=========================================");
            WriteLine("=========Cursos de la escuela============");

            if(escuela?.Cursos != null){
                foreach (var item in escuela.Cursos)
                {
                    WriteLine($"Nombre {item.Nombre}, Id{item.UniqueId}");
                }
            }

            WriteLine("=========================================");
        }
    
        // Esta función se llama por cada elemento dentro de la lista
        private static bool Predicado(Curso curso) {
            return curso.Nombre == "301";
        }

        private static int PredicadoMalHecho(Curso curso) {
            return 301;
        }
    }
}
