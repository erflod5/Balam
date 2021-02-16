using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.simbolo;

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

        public override Simbolo evaluar(Entorno entorno)
        {
            //TODO tipos
            return new Simbolo(this.valor, new Tipo(Tipos.INT, null), null);
        }
    }
}
