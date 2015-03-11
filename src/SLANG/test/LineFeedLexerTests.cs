﻿namespace SLANG
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SLANG.Core;

    [TestClass]
    public class LineFeedLexerTests
    {
        [TestMethod]
        public void ReadLf()
        {
            var text = "\n";
            var lexer = new LineFeedLexer();
            using (var reader = new StringReader(text))
            using (ITextScanner scanner = new TextScanner(reader))
            {
                scanner.Read();
                var element = lexer.Read(scanner);
                Assert.IsNotNull(element);
                Assert.AreEqual("\n", element.Data);
            }
        }
    }
}