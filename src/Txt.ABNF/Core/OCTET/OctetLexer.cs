﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctetLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Txt.Core;

namespace Txt.ABNF.Core.OCTET
{
    public class OctetLexer : Lexer<Octet>
    {
        protected override ReadResult<Octet> ReadImpl(ITextScanner scanner, ITextContext context)
        {
            var read = scanner.Read();
            if (read != -1)
            {
                return new ReadResult<Octet>(new Octet(read, context));
            }
            return new ReadResult<Octet>(new SyntaxError(true, "", "", context));
        }
    }
}
