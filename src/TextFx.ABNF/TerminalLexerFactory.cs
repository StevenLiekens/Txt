﻿namespace TextFx.ABNF
{
    using System;
    using System.Collections.Generic;

    /// <summary>Creates instances of the <see cref="TerminalLexer" /> class.</summary>
    public class TerminalLexerFactory : ITerminalLexerFactory
    {
        /// <inheritdoc />
        public ILexer<Terminal> Create(string terminal, IEqualityComparer<string> comparer)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
            return new TerminalLexer(terminal, comparer);
        }
    }
}