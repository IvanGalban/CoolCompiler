﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AST.Nodes.Abstract;
using Grammars;

namespace AST.Nodes
{
    public class NewNode : KeywordNode
    {
        public string TextType { get; set; }

        public NewNode(Token type)
        {
            TextType = type.Text;
            Line = type.Line;
            Column = type.Column;
        }
    }
}