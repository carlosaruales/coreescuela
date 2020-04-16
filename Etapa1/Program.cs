﻿using System;
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

            Console.WriteLine(escuela);
        }
    }
}
