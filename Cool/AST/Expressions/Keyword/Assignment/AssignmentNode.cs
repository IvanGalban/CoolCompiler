﻿using Antlr4.Runtime;
using Cool.Semantics;
using System.Collections.Generic;

namespace Cool.AST
{
    public class AssignmentNode : ExpressionNode
    {
        public IdentifierNode ID { get; set; }
        public ExpressionNode ExpressionRight { get; set; }

        public AssignmentNode(ParserRuleContext context) : base(context)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
}
