using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.expresion;

namespace ConsoleApp1.interprete.instruccion
{
    class If : Instruccion
    {
        private Expresion valor;
        private LinkedList<Instruccion> instrucciones;
        private Instruccion _else;

        public override object ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}
