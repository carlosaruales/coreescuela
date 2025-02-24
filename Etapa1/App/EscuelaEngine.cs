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

    #region metodos de carga
    private void CargarEvaluaciones()
    {
      var lista = new List<Evaluacion>();
      var rnd = new Random();
      foreach (var curso in escuela.Cursos)
      {
        foreach (var asignatura in curso.Asignatura)
        {
          foreach (var alumno in curso.Alumno)
          {
            for (int i = 0; i < 5; i++)
            {
              var ev = new Evaluacion
              {
                Asignatura = asignatura,
                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                Nota =  MathF.Round(
                  5 * (float)rnd.NextDouble(), 
                  2
                ),
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
  
    public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
      out int conteoEvaluaciones,
      out int conteoAsignaturas,
      out int conteoAlumnos,
      out int conteoCursos,
      bool traeEvaluaciones = true,
      bool traeAlumnos = true,
      bool traeAsignaturas = true,
      bool traeCursos = true
    ) {
      conteoAsignaturas = conteoEvaluaciones = conteoAlumnos = conteoCursos = 0;
      var listaObj = new List<ObjetoEscuelaBase>();
      listaObj.Add(escuela);
      listaObj.AddRange(escuela.Cursos);

      if(traeCursos){
        conteoCursos = escuela.Cursos.Count;
        foreach (var curso in escuela.Cursos)
        {
          
          if (traeAsignaturas){
            listaObj.AddRange(curso.Asignatura);
            conteoAsignaturas+= curso.Asignatura.Count;
          }
          
          if(traeAlumnos) {
            listaObj.AddRange(curso.Alumno);
            conteoAlumnos+= curso.Alumno.Count;
          }

          if(traeEvaluaciones) {
            foreach (var alumno in curso.Alumno)
            {
              listaObj.AddRange(alumno.Evaluaciones);
              conteoEvaluaciones+= alumno.Evaluaciones.Count;
            }
          }
        }
      }
      
      return listaObj.AsReadOnly();
    }
    
    
    public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
      bool traeEvaluaciones = true,
      bool traeAlumnos = true,
      bool traeAsignaturas = true,
      bool traeCursos = true
    ) {
      return GetObjetoEscuelas(
        out int dummy,
        out dummy, 
        out dummy,
        out dummy
      );
    }

    public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
      out int conteoEvaluaciones,
      bool traeEvaluaciones = true,
      bool traeAlumnos = true,
      bool traeAsignaturas = true,
      bool traeCursos = true
    ) {
      return GetObjetoEscuelas(
        out conteoEvaluaciones,
        out int dummy, 
        out dummy,
        out dummy
      );
    }

    public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
      out int conteoEvaluaciones,
      out int conteoAsignaturas,
      bool traeEvaluaciones = true,
      bool traeAlumnos = true,
      bool traeAsignaturas = true,
      bool traeCursos = true
    ) {
      return GetObjetoEscuelas(
        out conteoEvaluaciones,
        out conteoAsignaturas, 
        out int dummy,
        out dummy
      );
    }

    public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
      out int conteoEvaluaciones,
      out int conteoAsignaturas,
      out int conteoAlumnos,
      bool traeEvaluaciones = true,
      bool traeAlumnos = true,
      bool traeAsignaturas = true,
      bool traeCursos = true
    ) {
      return GetObjetoEscuelas(
        out conteoEvaluaciones,
        out conteoAsignaturas, 
        out conteoAlumnos,
        out int dummy
      );
    }

    public Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos() {
      var diccionario = new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();

      diccionario.Add(LlavesDiccionario.Escuela, new [] {escuela});
      diccionario.Add(LlavesDiccionario.Cursos, escuela.Cursos.Cast<ObjetoEscuelaBase>());
      var evaluaciones = new List<Evaluacion>();
      var asignaturas = new List<Asignatura>();
      var alumnos = new List<Alumno>();
      foreach(var curso in escuela.Cursos) {
        asignaturas.AddRange(curso.Asignatura);
        alumnos.AddRange(curso.Alumno);
        foreach (var alumno in curso.Alumno)
        {
          evaluaciones.AddRange(alumno.Evaluaciones);
        }
      }
      diccionario.Add(LlavesDiccionario.Asignaturas, asignaturas);
      diccionario.Add(LlavesDiccionario.Alumnos, alumnos);
      diccionario[LlavesDiccionario.Evaluaciones] = evaluaciones;
      

      return diccionario;
    }

    public void ImprimirDiccionario(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>  dic,
      bool impEval = false) {
      foreach (var item in dic)
      {
        foreach (var val in item.Value)
        {
          switch (item.Key)
          {
            case LlavesDiccionario.Evaluaciones:
              if(impEval) {
                Console.WriteLine(val);
              }
            break;

            case LlavesDiccionario.Escuela:
              Console.WriteLine(val);
            break;

            case LlavesDiccionario.Alumnos:
              Console.WriteLine(val);
            break;
            
            default:
              Console.WriteLine(val);
            break;
          }
        }
      }
    }

    #endregion
  }
}