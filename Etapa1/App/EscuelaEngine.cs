using Etapa1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Etapa1.App
{
    public class EscuelaEngine
    {
        public Escuela escuela {get; set;}

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
            foreach (var curso in escuela.Cursos)
            {   
                curso.Alumno.AddRange(CargarAlumnos());
            }
            CargarAsignaturas();
            CargarEvaluaciones();
        }

    private void CargarEvaluaciones()
    {
      throw new NotImplementedException();
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
        item.Asignatura.AddRange(listaAsignaturas);   
      }
    }

    private IEnumerable<Alumno> CargarAlumnos()
    {
        string[] nombre1 = {"Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas"};
        string[] apellido1 = {"Ruiz", "Ruales", "Acosta", "Polania", "Martinez", "Dyago", "Castellano"};
        string[] nombre2 = {"Carlos", "Andres", "Evelyn", "Katherine", "Johana", "Deyanira", "Marcela"};

        var listaAlumnos = from n1 in nombre1
                        from n2 in nombre2
                        from a1 in apellido1
                        select new Alumno { Nombre = $"{n1} {n2} {a1}" };

        return listaAlumnos;
    }

    private void CargarCursos()
        {
            escuela.Cursos = new List<Curso>() {
                new Curso() { Nombre = "101", Jornada= TiposJornada.Afternoon },
                new Curso() { Nombre = "201" },
                new Curso() { Nombre = "301" }
            };
        }
  }
}