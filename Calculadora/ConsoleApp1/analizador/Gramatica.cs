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
            var IF = ToTerm("if");
            var ELSE = ToTerm("else");

            var PTO_COMA = ToTerm(";");
            var PAR_ABRE = ToTerm("(");
            var PAR_CIERRA = ToTerm(")");

            var LLAVE_ABRE = ToTerm("{");
            var LLAVE_CIERRA = ToTerm("}");

            var MAS = ToTerm("+");
            var MENOS = ToTerm("-");
            var POR = ToTerm("*");
            var MOD = ToTerm("%");
            var DIV = ToTerm("/");

            var EQ = ToTerm("==");
            var NOTEQ = ToTerm("!=");
            var LESS = ToTerm("<");
            var GRT = ToTerm(">");

            #endregion

            #region NoTerminales
            NonTerminal Raiz = new NonTerminal("Raiz");
            NonTerminal Instrucciones = new NonTerminal("Instrucciones");
            NonTerminal Instruccion = new NonTerminal("Instruccion");
            NonTerminal Expr = new NonTerminal("Expr");
            NonTerminal If = new NonTerminal("If");
            NonTerminal Else = new NonTerminal("Else");
            NonTerminal Evaluar = new NonTerminal("Evaluar");
            #endregion

            #region Gramatica
            Raiz.Rule
                = Instrucciones;

            Instrucciones.Rule
                = MakePlusRule(Instrucciones, Instruccion)
                ;

            Instruccion.Rule
                = Evaluar
                | If
                ;
            Instruccion.ErrorRule
                = SyntaxError + PTO_COMA
                | SyntaxError + LLAVE_CIERRA
                ;

            Evaluar.Rule
                = EVALUAR + PAR_ABRE + Expr + PAR_CIERRA + PTO_COMA
                ;

            If.Rule
                = IF + PAR_ABRE + Expr + PAR_CIERRA + LLAVE_ABRE + Instrucciones + LLAVE_CIERRA + Else
                | IF + PAR_ABRE + Expr + PAR_CIERRA + LLAVE_ABRE + Instrucciones + LLAVE_CIERRA 
                ;

            Else.Rule
                = ELSE + LLAVE_ABRE + Instrucciones + LLAVE_CIERRA
                | ELSE + If
                ;

            Expr.Rule
                = Expr + MAS + Expr
                | Expr + MENOS + Expr
                | Expr + POR + Expr
                | Expr + DIV + Expr
                | Expr + MOD + Expr
                | Expr + EQ + Expr
                | Expr + NOTEQ + Expr
                | Expr + LESS + Expr
                | Expr + GRT + Expr
                | INT
                | DOUBLE
                ;
            #endregion

            #region Preferencias
            this.Root = Raiz;
            this.RegisterOperators(1, Associativity.Left, EQ, NOTEQ, LESS, GRT);
            this.RegisterOperators(2, Associativity.Left, MAS, MENOS);
            this.RegisterOperators(3, Associativity.Left, POR, DIV);
            this.RegisterOperators(4, Associativity.Left, MOD);
            #endregion
        }

    }
}
