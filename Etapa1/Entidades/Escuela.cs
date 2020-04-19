namespace Etapa1.Entidades
{
  class Escuela
  {
    public Escuela(string nombre, int ano, TiposEscuela tiposEscuela, string pais = "", string ciudad = "") {
      (Nombre, AnoCreacion) = (nombre, ano);
      Pais = pais;
      Ciudad =  ciudad;
    }

    public Escuela(string nombre, int ano) => (Nombre, AnoCreacion) = (nombre, ano);
    string nombre;

    public string Nombre {
      get {
        return nombre;
      }
      set {
        nombre = value;
      }
    }

    public int AnoCreacion { get; set; }
    public string Pais { get; set; }
    public string Ciudad { get; set; }

    public TiposEscuela TipoEscuela{ get; set;}

    public Curso[] Cursos {get; set;}

    public override string ToString() {
      return $"Nombre \"{Nombre},\" Tipo{TipoEscuela} {System.Environment.NewLine} Pais {Pais}, Ciudad {Ciudad}";
    }
  }
}