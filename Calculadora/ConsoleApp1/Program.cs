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
            analizador.analizar("if(1 == 1) { if(5 > 3 > 2 > 1 > 10){evaluar(1+2+3);} evaluar(1); } else{evaluar(3*2+1);} evaluar(3);");
            Console.WriteLine("Finalizando analizador!");
        }
    }
}
