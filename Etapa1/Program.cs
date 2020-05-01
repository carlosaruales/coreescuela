using System;
using Etapa1.Entidades;
using static System.Console;
using Etapa1.App;
using Etapa1.Util;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            Printer.DibujarLinea();
            Printer.DibujarLinea(20);
            ImprimirCursosEscuela(engine.escuela);
            Printer.DibujarLinea(20);
            Printer.DibujarLinea(20);
            Printer.DibujarLinea(20);
            Printer.WriteTitle("Pruebas de polimorfismo");
            var alumnoTest = new Alumno{
                Nombre = "Pepito perez"
            };
            
            // Printer.WriteTitle("Alumno");
            // WriteLine($"Alumno {alumnoTest.Nombre}");
            // WriteLine($"Alumno {alumnoTest.UniqueId}");
            // WriteLine($"Alumno {alumnoTest.GetType()}");

            // ObjetoEscuelaBase ob = alumnoTest;
            // Printer.WriteTitle("ObjetoEscuela");
            // WriteLine($"ObjetoEscuela {ob.Nombre}");
            // WriteLine($"ObjetoEscuela {ob.UniqueId}");
            // WriteLine($"ObjetoEscuela {ob.GetType()}");

            // var objDummy = new ObjetoEscuelaBase {
            //     Nombre = "Frank Underwood"
            // };
            // Printer.WriteTitle("objDummy");
            // WriteLine($"objDummy {objDummy.Nombre}");
            // WriteLine($"objDummy {objDummy.UniqueId}");
            // WriteLine($"objDummy {objDummy.GetType()}");

            // var evaluacion = new Evaluacion {
            //     Nombre = "Evaluación de matemática",
            //     Nota = 4.5f
            // };

            // Printer.WriteTitle("evaluacion");
            // WriteLine($"evaluacion {evaluacion.Nombre}");
            // WriteLine($"evaluacion {evaluacion.UniqueId}");
            // WriteLine($"evaluacion {evaluacion.Nota}");
            // WriteLine($"evaluacion {evaluacion.GetType()}");

            // ob = evaluacion;

            // Printer.WriteTitle("ObjetoEscuela");
            // WriteLine($"ObjetoEscuela {ob.Nombre}");
            // WriteLine($"ObjetoEscuela {ob.UniqueId}");
            // WriteLine($"ObjetoEscuela {ob.GetType()}");


            // if(ob is Alumno) {
            //     Alumno alumnoRecuperado = (Alumno)ob;
            // }

            // // Si no se puede transformar en alumno, alumnoRecuperado2 quedaría en null
            // Alumno alumnoRecuperado2 = ob as Alumno;


        }

        private static void ImprimirCursosEscuela(Escuela escuela) {
            Printer.WriteTitle("Cursos escuela");

            if(escuela?.Cursos != null){
                foreach (var item in escuela.Cursos)
                {
                    WriteLine($"Nombre {item.Nombre}, Id{item.UniqueId}");
                }
            }
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
