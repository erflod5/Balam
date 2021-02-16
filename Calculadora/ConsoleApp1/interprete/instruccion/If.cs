using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.interprete.expresion;
using ConsoleApp1.interprete.simbolo;

namespace ConsoleApp1.interprete.instruccion
{
    class If : Instruccion
    {
        private Expresion valor;
        private LinkedList<Instruccion> instrucciones;
        private Instruccion _else;

        public If(Expresion valor, LinkedList<Instruccion> instrucciones, Instruccion _else)
        {
            this.valor = valor;
            this.instrucciones = instrucciones;
            this._else = _else;
        }
        public override object ejecutar(Entorno entorno)
        {
            Simbolo valor = this.valor.evaluar(entorno);

            //TODO verificar errores
            if (valor.tipo.tipo != Tipos.BOOLEAN)
                throw new Exception("El tipo no es booleano para el IF");

            if(bool.Parse(valor.valor.ToString()))
            {
                try
                {
                    foreach (var instruccion in instrucciones)
                    {
                        instruccion.ejecutar(entorno);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                if (_else != null) _else.ejecutar(entorno);
            }
            return null;
        }
    }
}