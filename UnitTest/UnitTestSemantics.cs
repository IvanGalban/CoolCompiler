﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cool.AST;
using Cool.Parsing;
using Cool.Semantics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTestSemantics
    {
        [TestMethod]
        public void TestSemanticsSuccess()
        {
            UnitTestParsing testParsing = new UnitTestParsing();
            string directorySuccess = "../../../TestCases/Semantics/success/";
            DirectoryInfo directory = new DirectoryInfo(directorySuccess);
            FileInfo[] files = directory.GetFiles();

            foreach (var file in files)
            {
                var errors = new List<string>();
                List<string> errorParsing = testParsing.ParsingFile(file.FullName);

                foreach (var item in errorParsing)
                    Assert.Fail($"Parsing error in {file.Name}: {item}");

                var astBuilder = new ASTBuilder();
                ProgramNode program = astBuilder.Visit(testParsing.tree) as ProgramNode;

                Scope.Clear();
                var scope = new Scope();

                program = new Tour1().CheckSemantic(program, scope, errors);
                foreach (var item in errors)
                    Assert.Fail(file.Name + ": " + item.ToString());

                program = new Tour2().CheckSemantic(program, scope, errors);
                foreach (var item in errors)
                    Assert.Fail(file.Name + ": " + item.ToString());
            }
        }

        [TestMethod]
        public void TestSemanticsFail()
        {
            UnitTestParsing testParsing = new UnitTestParsing();
            string directoryFail = "../../../TestCases/Semantics/fail/";
            DirectoryInfo directory = new DirectoryInfo(directoryFail);
            FileInfo[] files = directory.GetFiles();

            foreach (var file in files)
            {
                var errors = new List<string>();
                List<string> errorParsing = testParsing.ParsingFile(file.FullName);

                if(errorParsing.Any())
                {
                    Assert.IsTrue(errorParsing.Any());
                    continue;
                }

                var astBuilder = new ASTBuilder();
                ProgramNode program = astBuilder.Visit(testParsing.tree) as ProgramNode;

                Scope.Clear();
                var scope = new Scope();

                program = new Tour1().CheckSemantic(program, scope, errors);
                if(errors.Any())
                {
                    Assert.IsTrue(errors.Any(), file.Name);
                }
                else
                {
                    program = new Tour2().CheckSemantic(program, scope, errors);
                    Assert.IsTrue(errors.Any(), file.Name);
                }
            }
        }
    }
}
