using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.interprete.util
{
    class ErrorPascal : Exception
    {
        private int linea, columna;
        private string mensaje;
        private string tipo;

        public ErrorPascal(int linea, int columna, string mensaje, string tipo)
        {
            this.linea = linea;
            this.columna = columna;
            this.mensaje = mensaje;
            this.tipo = tipo;
        }

        public override string ToString()
        {
            return "Se encontro un error: " + this.tipo + " - En la linea " + this.linea + " - Mensaje: " + this.mensaje;
        }
    }
}
