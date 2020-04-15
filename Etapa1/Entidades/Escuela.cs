namespace Etapa1.Entidades
{
  class Escuela
  {
    // public Escuela(string nombre, int ano) {
    //   this.nombre = nombre;
    //   AnoCreacion = ano;
    // }

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

    public override string ToString() {
      return $"Nombre {Nombre}, Tipo{TipoEscuela} \n Pais {Pais}, Ciudad {Ciudad}";
    }
  }
}