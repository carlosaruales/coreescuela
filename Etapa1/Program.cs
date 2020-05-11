using System;
using Etapa1.Entidades;
using static System.Console;
using Etapa1.App;
using Etapa1.Util;
using System.Collections.Generic;

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
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(10, "Carlos");
            dictionary.Add(23, "Lorem Ipsum");

            foreach (var item in dictionary)
            {
                WriteLine($"Key: {item.Key} Valor:{item.Value}");
            }

            dictionary[0] = "Pekerman";
            Printer.WriteTitle("Acceso a diccionario");
            WriteLine(dictionary[23]);

            Printer.WriteTitle("Otro diccionario");
            var dic = new Dictionary<string, string>();
            dic["luna"] = "cuerpo celeste";
            WriteLine(dic["luna"]);
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
