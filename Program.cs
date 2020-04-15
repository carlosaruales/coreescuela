using System;

namespace CoreEscuela
{
    class Escuela{
        public string nombre;
        public string direccion;
        public int fundacion;
        public string ceo;
        
        public void Timbrar() {
            //Todo
            Console.Beep(10000, 3000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Escuela(); //copia de la escuela
            miEscuela.nombre = "Platzi Academy";
            miEscuela.direccion = "Bogotá";
            miEscuela.fundacion = 100;
            Console.WriteLine("Timbrando...");
            

            miEscuela.Timbrar();
        }
    }
}
