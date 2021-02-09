﻿using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;

namespace ConsoleApp1.analizador
{
    public class Graficador
    {
        private static int contador;
        private static string grafo;

        public static string getDot(ParseTreeNode raiz)
        {
            grafo = "digraph G{";
            grafo += "nodo0[label=\"" + escapar(raiz.ToString()) + "\"];\n";
            contador = 1;
            recorrerAst("nodo0", raiz);
            grafo += "}";
            return grafo;
        }

        private static void recorrerAst(string padre, ParseTreeNode raiz)
        {
            foreach (ParseTreeNode hijo in raiz.ChildNodes)
            {
                String nameHijo = "nodo" + contador.ToString();
                grafo += nameHijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";
                grafo += padre + "->" + nameHijo + ";\n";
                contador++;
                recorrerAst(nameHijo, hijo);
            }
        }

        private static string escapar(string cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
