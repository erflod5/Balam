using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.interprete.expresion
{
    class Aritmetica : Expresion
    {
        private Expresion izquierda;
        private Expresion derecha;
        private char tipo;

        public Aritmetica(Expresion izquierda, Expresion derecha, char tipo)
        {
            this.izquierda = izquierda;
            this.derecha = derecha;
            this.tipo = tipo;
        }
        public override double evaluar()
        {
            double izquierda = this.izquierda.evaluar();
            double derecha = this.derecha.evaluar();
            switch (tipo)
            {
                case '+':
                    return izquierda + derecha;
                case '-':
                    return izquierda - derecha;
                case '*':
                    return izquierda * derecha;
                case '/':
                    return izquierda / derecha;
                default:
                    return izquierda % derecha;
            }
        }
    }
}
