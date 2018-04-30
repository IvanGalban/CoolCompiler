﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool.CodeGeneration.IntermediateCode.ThreeAddressCode
{
    public abstract class AssignmentLine : CodeLine
    {
        public int Left { get; protected set; }
        public int Right { get; protected set; }
    }

    public class AssignmentVariableToMemoryLine : AssignmentLine
    {
        public int Offset { get; }
        public AssignmentVariableToMemoryLine(int left, int right, int offset = 0)
        {
            Left = left;
            Right = right;
            Offset = offset;
        }
    }

    public class AssignmentConstantToMemoryLine : AssignmentLine
    {
        public int Offset { get; }
        public AssignmentConstantToMemoryLine(int left, int right, int offset = 0)
        {
            Left = left;
            Right = right;
            Offset = offset;
        }
    }

    public class AssignmentMemoryToVariableLine : AssignmentLine
    {
        public int Offset { get; }

        public AssignmentMemoryToVariableLine(int left, int right, int offset = 0)
        {
            Left = left;
            Right = right;
            Offset = offset;
        }
    }


    public class AssignmentConstantToVariableLine : AssignmentLine
    {

        public AssignmentConstantToVariableLine(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }
}