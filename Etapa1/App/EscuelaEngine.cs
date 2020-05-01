using Etapa1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Etapa1.App
{
  public sealed class EscuelaEngine
  {
    public Escuela escuela { get; set; }

    public EscuelaEngine()
    {

    }

    public void Inicializar()
    {
      escuela = new Escuela(
        "Platzi",
        2012,
        TiposEscuela.Primaria,
        ciudad: "Pradera"
      );

      CargarCursos();
      CargarAsignaturas();
      CargarEvaluaciones();
    }

    private void CargarEvaluaciones()
    {
      var lista = new List<Evaluacion>();
      foreach (var curso in escuela.Cursos)
      {
        foreach (var asignatura in curso.Asignatura)
        {
          foreach (var alumno in curso.Alumno)
          {
            var rnd = new Random(System.Environment.TickCount);
            for (int i = 0; i < 5; i++)
            {
              var ev = new Evaluacion
              {
                Asignatura = asignatura,
                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                Nota = (float)(5 * rnd.NextDouble()),
                Alumno = alumno
              };
              // lista.Add(ev);
              alumno.Evaluaciones.Add(ev);
            }
            // alumno.Evaluaciones.AddRange(lista);
          }
        }
      }
    }

    private void CargarAsignaturas()
    {
      foreach (var item in escuela.Cursos)
      {
        List<Asignatura> listaAsignaturas = new List<Asignatura>{
            new Asignatura{Nombre="Matematicas"},
            new Asignatura{Nombre="Educación fisica"},
            new Asignatura{Nombre="Castellano"},
            new Asignatura{Nombre="Ciencias naturales"},

        };
        item.Asignatura = listaAsignaturas;
      }
    }

    private List<Alumno> GenerarAlumnos(int cantidad)
    {
      string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas" };
      string[] apellido1 = { "Ruiz", "Ruales", "Acosta", "Polania", "Martinez", "Dyago", "Castellano" };
      string[] nombre2 = { "Carlos", "Andres", "Evelyn", "Katherine", "Johana", "Deyanira", "Marcela" };

      var listaAlumnos = from n1 in nombre1
                         from n2 in nombre2
                         from a1 in apellido1
                         select new Alumno { Nombre = $"{n1} {n2} {a1}" };

      return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
    }

    private void CargarCursos()
    {
      escuela.Cursos = new List<Curso>() {
        new Curso() { Nombre = "101", Jornada= TiposJornada.Afternoon },
        new Curso() { Nombre = "201" },
        new Curso() { Nombre = "301" }
      };

      foreach (var curso in escuela.Cursos)
      {
        curso.Alumno = GenerarAlumnos(new Random().Next(5, 20));
      }
    }
  
    public List<ObjetoEscuelaBase> GetObjetoEscuelas() {
      var listaObj = new List<ObjetoEscuelaBase>();
      listaObj.Add(escuela);
      listaObj.AddRange(escuela.Cursos);

      foreach (var curso in escuela.Cursos)
      {
        listaObj.AddRange(curso.Asignatura);
        listaObj.AddRange(curso.Alumno);

        foreach (var alumno in curso.Alumno)
        {
          listaObj.AddRange(alumno.Evaluaciones);
        }
      }
      
      return listaObj;
    }
  }
}