using System.Collections.Generic;
using Etapa1.Util;
using System;

namespace Etapa1.Entidades
{
  public class Escuela: ObjetoEscuelaBase, ILugar
  {
    public Escuela(string nombre, int ano, TiposEscuela tiposEscuela, string pais = "", string ciudad = "") {
      (Nombre, AnoCreacion) = (nombre, ano);
      Pais = pais;
      Ciudad =  ciudad;
    }

    public Escuela(string nombre, int ano) => (Nombre, AnoCreacion) = (nombre, ano);

    public int AnoCreacion { get; set; }
    public string Pais { get; set; }
    public string Ciudad { get; set; }

    public TiposEscuela TipoEscuela{ get; set;}

    public List<Curso> Cursos {get; set;}

    public override string ToString() {
      return $"Nombre \"{Nombre},\" Tipo{TipoEscuela} {System.Environment.NewLine} Pais {Pais}, Ciudad {Ciudad}";
    }

    public string Direccion {get; set;}

    public void LimpiarLugar() {
      Printer.DibujarLinea();
      Console.WriteLine("Limpiando escuela...");
      foreach (var curso in Cursos)
      {
        curso.LimpiarLugar();
      }
      Console.WriteLine($"Escuela {Nombre} limpia");
    }
  }
}