﻿using Antlr4.Runtime;
using Cool.Semantics;

namespace Cool.AST
{
    public abstract class ArithmeticOperation : BinaryOperationNode
    {
        public ArithmeticOperation(ParserRuleContext context) : base(context)
        {
        }
    }
}
