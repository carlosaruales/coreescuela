namespace Etapa1.Entidades
{
    public class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = System.Guid.NewGuid().ToString();
        }

        public override string ToString(){
            return $"{Nombre}, {UniqueId}";
        }
    }
}