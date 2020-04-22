using System;
using Etapa1.Entidades;
using static System.Console;
using System.Collections.Generic;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela  = new Escuela("Platzi", 2012, TiposEscuela.Primaria, ciudad: "Pradera");
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";

            escuela.Cursos = new List<Curso>() {
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso() { Nombre = "301" }
            };

            escuela.Cursos.Add(
               new Curso { Nombre = "401", Jornada= TiposJornada.Morning}
            );

            escuela.Cursos.Add(
               new Curso { Nombre = "202", Jornada= TiposJornada.Morning}
            );

            var otraColeccion = new List<Curso>() {
                new Curso() { Nombre = "501" },
                new Curso() { Nombre = "601" },
                new Curso() { Nombre = "602" }
            };
            Curso tmp = new Curso {
                Nombre = "vacacional",
                Jornada = TiposJornada.Afternoon
            };
            otraColeccion.Clear();
            escuela.Cursos.AddRange(otraColeccion);
            escuela.Cursos.Add(tmp);
            escuela.Cursos.Remove(tmp);
            // Predicate<Curso>miAlgoritmo = Predicado;

            escuela.Cursos.RemoveAll(delegate (Curso cur) {
                return cur.Nombre == "301";
            });

            escuela.Cursos.RemoveAll((cur) => 
                cur.Nombre == "301" && 
                cur.Jornada == TiposJornada.Morning
            );

            ImprimirCursosEscuela(escuela);


            
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos) {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id{arregloCursos[contador].UniqueId}");
                contador+= 1;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos) {
            int contador = 0;
            do 
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id{arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos) {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre}, Id{arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos) {
            foreach (var item in arregloCursos)
            {
                WriteLine($"Nombre {item.Nombre}, Id{item.UniqueId}");
            }
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
