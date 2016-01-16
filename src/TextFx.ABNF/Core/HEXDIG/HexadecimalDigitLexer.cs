﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HexadecimalDigitLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TextFx.ABNF.Core
{
    using System;
    using System.Diagnostics;
    using JetBrains.Annotations;

    public class HexadecimalDigitLexer : Lexer<HexadecimalDigit>
    {
        [DebuggerBrowsable(SwitchOnBuild.DebuggerBrowsableState)]
        private readonly ILexer<Alternative> innerLexer;

        /// <summary>
        /// </summary>
        /// <param name="innerLexer">DIGIT / "A" / "B" / "C" / "D" / "E" / "F"</param>
        public HexadecimalDigitLexer([NotNull] ILexer<Alternative> innerLexer)
        {
            if (innerLexer == null)
            {
                throw new ArgumentNullException(nameof(innerLexer));
            }
            this.innerLexer = innerLexer;
        }

        public override ReadResult<HexadecimalDigit> Read(ITextScanner scanner)
        {
            var context = scanner.GetContext();
            var result = innerLexer.Read(scanner);
            if (result.Success)
            {
                return ReadResult<HexadecimalDigit>.FromResult(new HexadecimalDigit(result.Element));
            }
            return ReadResult<HexadecimalDigit>.FromSyntaxError(SyntaxError.FromReadResult(result, context));
        }
    }
}
