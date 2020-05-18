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
            AppDomain.CurrentDomain.ProcessExit+= AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit+= (Object sender, EventArgs e) => Printer.WriteTitle("Despues de salir");
            AppDomain.CurrentDomain.ProcessExit-= AccionDelEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            reporteador.GetDicEvaluacionesXAsignatura();
            reporteador.GetPromedioAlumnosXAsig();

            Printer.WriteTitle("Captura de una evaluación por consola");
            var newEval = new Evaluacion();
            string nombre, notaString;
            float nota;
            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();
            if(string.IsNullOrEmpty(nombre)) {
                throw new ArgumentException("el valor del nombre no puede ser vacio");
            } else {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();
            if(string.IsNullOrEmpty(notaString)) {
                throw new ArgumentException("el valor del nombre no puede ser vacio");
            } else {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if(newEval.Nota < 0 || newEval.Nota > 5) {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido ingresada correctamente");
                }
                catch( ArgumentOutOfRangeException arg) {
                    WriteLine(arg.Message);
                }
                catch (System.Exception)
                {
                    WriteLine("El valor de la nota no es un número válido");
                }
            }
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

        private static void AccionDelEvento(Object sender, EventArgs e) {
            Printer.WriteTitle("Saliendo...");
        }
    }
}
