using System.Collections.Generic;
using Etapa1.Util;
using System;
namespace Etapa1.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignatura {get; set;}
        public List<Alumno> Alumno {get; set;}

        public string Direccion {get; set;}

        public void LimpiarLugar() {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando establecimiento...");
            Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}