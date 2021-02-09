using System;
using System.Collections.Generic;
using System.Text;
using Irony.Ast;
using Irony.Parsing;

namespace ConsoleApp1.analizador
{
    class Gramatica : Grammar
    {

        public Gramatica() : base(caseSensitive: false)
        {

            #region ER
            var INT = new NumberLiteral("INT");
            var DOUBLE = new RegexBasedTerminal("DOUBLE", "[0-9]+[.][0-9]+");
            #endregion

            #region Terminales
            var EVALUAR = ToTerm("evaluar");

            var PTO_COMA = ToTerm(";");
            var PAR_ABRE = ToTerm("(");
            var PAR_CIERRA = ToTerm(")");

            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var POR = ToTerm("*");
            var MOD = ToTerm("%");
            var DIV = ToTerm("/");
            #endregion

            #region NoTerminales
            NonTerminal Raiz = new NonTerminal("Raiz");
            NonTerminal Instrucciones = new NonTerminal("Instrucciones");
            NonTerminal Instruccion = new NonTerminal("Instruccion");
            NonTerminal Expr = new NonTerminal("Expr");
            #endregion

            #region Gramatica
            Raiz.Rule
                = Instrucciones;

            Instrucciones.Rule
                = MakePlusRule(Instrucciones, Instruccion)
                ;

            Instruccion.Rule
                = EVALUAR + PAR_ABRE + Expr + PAR_CIERRA + PTO_COMA
                ;
            Instruccion.ErrorRule
                = SyntaxError + PTO_COMA;

            Expr.Rule
                = Expr + MAS + Expr
                | Expr + MENOS + Expr
                | Expr + POR + Expr
                | Expr + DIV + Expr
                | Expr + MOD + Expr
                | INT
                | DOUBLE
                ;
            #endregion

            #region Preferencias
            this.Root = Raiz;
            this.RegisterOperators(1, Associativity.Left, MAS, MENOS);
            this.RegisterOperators(2, Associativity.Left, POR, DIV);
            this.RegisterOperators(3, Associativity.Left, MOD);
            #endregion
        }

    }
}
