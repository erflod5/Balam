using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.expresion;

namespace ConsoleApp1.interprete.instruccion
{
    class Evaluar : Instruccion
    {
        private Expresion valor;

        public Evaluar(Expresion valor)
        {
            this.valor = valor;
        }

        public override object ejecutar()
        {
            double valor = this.valor.evaluar();
            Console.WriteLine("El valor es: " + valor);
            return null;
        }
    }
}
