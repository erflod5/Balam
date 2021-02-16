using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Irony.Ast;
using Irony.Parsing;
using ConsoleApp1.interprete.expresion;
using ConsoleApp1.interprete.instruccion;
using ConsoleApp1.interprete.simbolo;

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
            Entorno global = new Entorno(null);
            foreach (var instruccion in instrucciones)
            {
                instruccion.ejecutar(global);
            }
        }
        public LinkedList<Instruccion> instrucciones(ParseTreeNode actual)
        {
            LinkedList<Instruccion> listaInstrucciones = new LinkedList<Instruccion>();
            foreach(ParseTreeNode nodo in actual.ChildNodes)
            {
                listaInstrucciones.AddLast(instruccion(nodo.ChildNodes[0]));
            }
            return listaInstrucciones;
        }

        public Instruccion instruccion(ParseTreeNode actual)
        {
            switch (actual.ChildNodes[0].Token.Text)
            {
                case "evaluar":
                    return new Evaluar(expresion(actual.ChildNodes[2]));
                case "if":
                    if(actual.ChildNodes.Count == 8)
                    {
                        return new If(expresion(actual.ChildNodes[2]), instrucciones(actual.ChildNodes[5]),instruccion(actual.ChildNodes[7]));
                    }
                    else
                    {
                        return new If(expresion(actual.ChildNodes[2]), instrucciones(actual.ChildNodes[5]), null);
                    }
                case "else":
                    if(actual.ChildNodes.Count == 2)
                    {
                        return new Else(instruccion(actual.ChildNodes[1]));
                    }
                    else
                    {
                        return new Else(instrucciones(actual.ChildNodes[2]));
                    }
            }
            return null;
        }

        public Expresion expresion(ParseTreeNode actual)
        {
            if(actual.ChildNodes.Count == 3)
            {
                string operador = actual.ChildNodes[1].Token.Text;
                switch (operador)
                {
                    case "+":
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '+');
                    case "-":
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '-');
                    case "*":
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '*');
                    case "/":
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '/');
                    case "==":
                        return new Relacional(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '=');
                    case "!=":
                        return new Relacional(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '!');
                    case ">":
                        return new Relacional(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '>');
                    case "<":
                        return new Relacional(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '<');
                    default:
                        return new Aritmetica(expresion(actual.ChildNodes[0]), expresion(actual.ChildNodes[2]), '%');
                }
            }
            else
            {
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
