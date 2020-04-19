using System;
using Etapa1.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela  = new Escuela("Platzi", 2012, TiposEscuela.Primaria, ciudad: "Pradera");
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";

            Curso[] arregloCursos =  new Curso[]{
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso() { Nombre = "301" }
            };

            ImprimirCursosEscuela(escuela);

            // var arregloCursos = new Curso[3] {
            //     new Curso() { Nombre = "101" },
            //     new Curso() { Nombre = "201" },
            //     new Curso() { Nombre = "301" }
            // };

            // var arregloCursos = new Curso[] {
            //     new Curso() { Nombre = "101" },
            //     new Curso() { Nombre = "201" },
            //     new Curso() { Nombre = "301" }
            // };

            // Console.WriteLine("=======================");
            // ImprimirCursosWhile(arregloCursos);
            
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
    }
}
