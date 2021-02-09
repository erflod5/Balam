using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Irony.Ast;
using Irony.Parsing;
using ConsoleApp1.interprete.expresion;
using ConsoleApp1.interprete.instruccion;

namespace ConsoleApp1.analizador
{
    class Analizador
    {
        public void analizar(string cadena)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            foreach(var item in lenguaje.Errors)
            {
                Console.WriteLine(item);
            }

            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            if(raiz == null)
            {
                Console.WriteLine(arbol.ParserMessages[0].Message);
                return;
            }
            generarGrafo(raiz);
            LinkedList<Instruccion> listaInstrucciones = instrucciones(raiz.ChildNodes[0]);
            ejecutar(listaInstrucciones);
        }

        public void ejecutar(LinkedList<Instruccion> instrucciones)
        {
            foreach (var instruccion in instrucciones)
            {
                instruccion.ejecutar();
            }
        }
        public LinkedList<Instruccion> instrucciones(ParseTreeNode actual)
        {
            LinkedList<Instruccion> listaInstrucciones = new LinkedList<Instruccion>();
            foreach(ParseTreeNode nodo in actual.ChildNodes)
            {
                //Console.WriteLine(expresion(nodo.ChildNodes[2]));
                listaInstrucciones.AddLast(new Evaluar(expresion(nodo.ChildNodes[2])));
            }
            return listaInstrucciones;
        }

        public Expresion expresion(ParseTreeNode actual)
        {
            if(actual.ChildNodes.Count == 3)
            {
                string operador = actual.ChildNodes[1].Token.Text;
                switch (operador)
                {
                    case "+":
                        //return expresion(actual.ChildNodes[0]) + expresion(actual.ChildNodes[2]);
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '+');
                    case "-":
                        //return expresion(actual.ChildNodes[0]) - expresion(actual.ChildNodes[2]);
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '-');
                    case "*":
                        //return expresion(actual.ChildNodes[0]) * expresion(actual.ChildNodes[2]);
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '*');
                    case "/":
                        //return expresion(actual.ChildNodes[0]) / expresion(actual.ChildNodes[2]);
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '/');
                    default:
                        //return expresion(actual.ChildNodes[0]) % expresion(actual.ChildNodes[2]);
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '%');
                }
            }
            else
            {
                //return double.Parse(actual.ChildNodes[0].Token.Text);
                //TODO ver tipos
                return new Literal('N', actual.ChildNodes[0].Token.Text);
            }
        }

        public void generarGrafo(ParseTreeNode raiz)
        {
            string grafoDot = Graficador.getDot(raiz);
            string path = "ast.txt";
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(grafoDot);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
