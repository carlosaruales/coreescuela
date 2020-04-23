using static System.Console;

namespace Etapa1.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10) {
            var linea = "".PadLeft(tam, '=');
            WriteLine(linea);
        }

        public static void WriteTitle(string titulo) {
            int tamano = titulo.Length + 4;
            DibujarLinea(tamano);
            WriteLine($"| {titulo} |");
            DibujarLinea(tamano);
        }
    }
}