using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.expresion;

namespace ConsoleApp1.interprete.instruccion
{
    class Else : Instruccion
    {
        private LinkedList<Instruccion> instrucciones;

        public Else(LinkedList<Instruccion> instrucciones)
        {
            this.instrucciones = instrucciones;
        }

        public Else(Instruccion instruccion)
        {
            this.instrucciones = new LinkedList<Instruccion>();
            this.instrucciones.AddLast(instruccion);
        }

        public override object ejecutar()
        {
            foreach(var instruccion in instrucciones)
            {
                instruccion.ejecutar();
            }
            return null;
        }
    }
}
