using System;
using Etapa1.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela  = new Escuela("Platzi", 2012, TiposEscuela.Primaria, ciudad: "Pradera");
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";
            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso() {
                Nombre = "101"
            };

            var curso2 = new Curso() {
                Nombre = "201"
            };

            arregloCursos[1] = curso2;
            arregloCursos[2] = new Curso() {
                Nombre = "301"
            };

            Console.WriteLine(escuela);
            Console.WriteLine("=======================");
            ImprimirCursosWhile(arregloCursos);
            
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
                Console.WriteLine($"Nombre {item.Nombre}, Id{item.UniqueId}");
            }
        }
    }
}
