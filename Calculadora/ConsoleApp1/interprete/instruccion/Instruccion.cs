﻿using ConsoleApp1.interprete.simbolo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.interprete.instruccion
{
    abstract class Instruccion
    {
        public abstract object ejecutar(Entorno entorno);
    }
}
