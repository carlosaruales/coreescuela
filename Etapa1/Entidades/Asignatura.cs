namespace Etapa1.Entidades
{
    public class Asignatura
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public Asignatura() => UniqueId = System.Guid.NewGuid().ToString();
    }
}