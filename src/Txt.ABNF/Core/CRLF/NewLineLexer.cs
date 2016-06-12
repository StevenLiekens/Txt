﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewLineLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using JetBrains.Annotations;
using Txt.Core;

namespace Txt.ABNF.Core.CRLF
{
    public class NewLineLexer : Lexer<NewLine>
    {
        [DebuggerBrowsable(SwitchOnBuild.DebuggerBrowsableState)]
        private readonly ILexer<Concatenation> innerLexer;

        /// <summary>
        /// </summary>
        /// <param name="innerLexer">CR LF</param>
        public NewLineLexer([NotNull] ILexer<Concatenation> innerLexer)
        {
            if (innerLexer == null)
            {
                throw new ArgumentNullException(nameof(innerLexer));
            }
            this.innerLexer = innerLexer;
        }

        protected override ReadResult<NewLine> ReadImpl(ITextScanner scanner, ITextContext context)
        {
            var result = innerLexer.Read(scanner);
            if (result.Success)
            {
                return new ReadResult<NewLine>(new NewLine(result.Element));
            }
            return new ReadResult<NewLine>(SyntaxError.FromReadResult(result, context));
        }
    }
}
