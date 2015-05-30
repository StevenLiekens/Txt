﻿namespace SLANG.Core
{
    using Xunit;

    public class BitLexerTests
    {
        [Fact]
        public void CanReadZero()
        {
            var input = "0";
            var bitLexer = new BitLexer(new BitAlternativeLexer(new ZeroTerminalLexer(), new OneTerminalLexer()));
            using (var scanner = new TextScanner(new PushbackInputStream(input.ToMemoryStream())))
            {
                scanner.Read();
                var bit = bitLexer.Read(scanner);
                Assert.Equal(input, bit.Data);
            }
        }

        [Fact]
        public void CanReadOne()
        {
            var input = "1";
            var bitLexer = new BitLexer(new BitAlternativeLexer(new ZeroTerminalLexer(), new OneTerminalLexer()));
            using (var scanner = new TextScanner(new PushbackInputStream(input.ToMemoryStream())))
            {
                scanner.Read();
                var bit = bitLexer.Read(scanner);
                Assert.Equal(input, bit.Data);
            }
        }

        [Fact]
        public void CannotReadNegativeOne()
        {
            var input = "-1";
            var bitLexer = new BitLexer(new BitAlternativeLexer(new ZeroTerminalLexer(), new OneTerminalLexer()));
            using (var scanner = new TextScanner(new PushbackInputStream(input.ToMemoryStream())))
            {
                scanner.Read();
                Assert.Throws<SyntaxErrorException>(() => bitLexer.Read(scanner));
            }
        }
    }
}
