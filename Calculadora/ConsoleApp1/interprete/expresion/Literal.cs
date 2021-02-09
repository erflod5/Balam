using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.interprete.expresion
{
    class Literal : Expresion
    {
        private char tipo;
        private object valor;

        public Literal(char tipo, object valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }

        public override double evaluar()
        {
            //TODO tipos
            return double.Parse(valor.ToString());
        }
    }
}
