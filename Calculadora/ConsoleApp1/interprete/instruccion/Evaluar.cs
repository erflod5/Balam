using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.expresion;
using ConsoleApp1.interprete.simbolo;

namespace ConsoleApp1.interprete.instruccion
{
    class Evaluar : Instruccion
    {
        private Expresion valor;

        public Evaluar(Expresion valor)
        {
            this.valor = valor;
        }

        public override object ejecutar(Entorno entorno)
        {
            Simbolo valor = this.valor.evaluar(entorno);
            Console.WriteLine(valor.valor.ToString());
            return null;
        }
    }
}
