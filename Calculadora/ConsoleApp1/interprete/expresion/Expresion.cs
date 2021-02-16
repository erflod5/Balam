using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.simbolo;

namespace ConsoleApp1.interprete.expresion
{
    abstract class Expresion
    {
        public abstract Simbolo evaluar(Entorno entorno);
    }
}
