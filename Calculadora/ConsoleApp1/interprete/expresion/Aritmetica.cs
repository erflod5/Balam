using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.simbolo;

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
        public override Simbolo evaluar(Entorno entorno)
        {
            Simbolo izquierda = this.izquierda.evaluar(entorno);
            Simbolo derecha = this.derecha.evaluar(entorno);
            Simbolo resultado;
            Tipos tipoResultante = util.TablaTipos.getTipo(izquierda.tipo, derecha.tipo);

            if (tipoResultante != Tipos.INT && tipo != '+')
                throw new Exception();

            switch (tipo)
            {
                case '+':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) + double.Parse(derecha.ToString()), izquierda.tipo, null);
                    return resultado;
                case '-':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) - double.Parse(derecha.ToString()), izquierda.tipo, null);
                    return resultado;
                case '*':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) * double.Parse(derecha.ToString()), izquierda.tipo, null);
                    return resultado;
                case '/':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) / double.Parse(derecha.ToString()), izquierda.tipo, null);
                    return resultado;
                default:
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) % double.Parse(derecha.ToString()), izquierda.tipo, null);
                    return resultado;
            }
        }
    }
}
