using System;
using ConsoleApp1.analizador;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando analizador!");
            Analizador analizador = new Analizador();
            analizador.analizar("evaluar(1+2+3); evaluar(3*2+1);");
            Console.WriteLine("Finalizando analizador!");
        }
    }
}
