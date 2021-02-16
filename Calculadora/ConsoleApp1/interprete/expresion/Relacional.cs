using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.simbolo;
using ConsoleApp1.interprete.util;

namespace ConsoleApp1.interprete.expresion
{
    class Relacional : Expresion
    {
        private Expresion izquierda;
        private Expresion derecha;
        private char tipoOperacion;

        public Relacional(Expresion izquierda, Expresion derecha, char tipoOperacion)
        {
            this.izquierda = izquierda;
            this.derecha = derecha;
            this.tipoOperacion = tipoOperacion;
        }
        public override Simbolo evaluar(Entorno entorno)
        {
            Simbolo izquierda = this.izquierda.evaluar(entorno);
            Simbolo derecha = this.derecha.evaluar(EntryPointNotFoundException);
            Simbolo resultado;
            Tipo tipo = new Tipo(Tipos.BOOLEAN, null);

            Tipos tipoResultante = TablaTipos.getTipo(izquierda.tipo, derecha.tipo);
            if (tipoResultante == Tipos.ERROR)
                throw new ErrorPascal(0, 0, "Tipos de dato incorrectos", "Semantico");

            switch (tipoOperacion)
            {
                case '=':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) == double.Parse(derecha.ToString()), tipo, null);
                    return resultado;
                case '!':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) != double.Parse(derecha.ToString()), tipo, null);
                    return resultado;
                case '>':
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) > double.Parse(derecha.ToString()), tipo, null);
                    return resultado;
                default:
                    resultado = new Simbolo(double.Parse(izquierda.ToString()) < double.Parse(derecha.ToString()), tipo, null);
                    return resultado;
            }

        }
    }

}
