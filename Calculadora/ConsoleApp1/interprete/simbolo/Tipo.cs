using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.interprete.simbolo
{
    public enum Tipos
    {
        INT = 0,
        BOOLEAN = 1,
        ERROR = 2
    }
    class Tipo
    {
        public Tipos tipo;
        public string tipoAuxiliar;

        public Tipo(Tipos tipo, string tipoAuxiliar)
        {
            this.tipo = tipo;
            this.tipoAuxiliar = tipoAuxiliar;
        }
    }
}
