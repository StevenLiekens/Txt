﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EndOfLineLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Text.Scanning.Core
{
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>TODO </summary>
    public class EndOfLineLexer : Lexer<EndOfLine>
    {
        /// <summary>TODO </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ILexer<CarriageReturn> crLexer;

        /// <summary>TODO </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ILexer<LineFeed> lfLexer;

        /// <summary>TODO </summary>
        public EndOfLineLexer()
            : this(new CarriageReturnLexer(), new LineFeedLexer())
        {
        }

        /// <summary>TODO </summary>
        /// <param name="crLexer">TODO </param>
        /// <param name="lfLexer">TODO </param>
        public EndOfLineLexer(ILexer<CarriageReturn> crLexer, ILexer<LineFeed> lfLexer)
        {
            Contract.Requires(crLexer != null);
            Contract.Requires(lfLexer != null);
            this.crLexer = crLexer;
            this.lfLexer = lfLexer;
        }

        /// <inheritdoc />
        public override EndOfLine Read(ITextScanner scanner)
        {
            var context = scanner.GetContext();
            try
            {
                var cr = this.crLexer.Read(scanner);
                var lf = this.lfLexer.Read(scanner);
                Contract.Assume(lf.Offset == cr.Offset + 1);
                return new EndOfLine(cr, lf, context);
            }
            catch (SyntaxErrorException syntaxErrorException)
            {
                throw new SyntaxErrorException(context, "Expected 'CRLF'", syntaxErrorException);
            }
        }

        /// <inheritdoc />
        public override bool TryRead(ITextScanner scanner, out EndOfLine element)
        {
            var context = scanner.GetContext();
            CarriageReturn carriageReturn;
            if (scanner.EndOfInput || !this.crLexer.TryRead(scanner, out carriageReturn))
            {
                element = default(EndOfLine);
                return false;
            }

            LineFeed lineFeed;
            if (scanner.EndOfInput || !this.lfLexer.TryRead(scanner, out lineFeed))
            {
                this.crLexer.PutBack(scanner, carriageReturn);
                element = default(EndOfLine);
                return false;
            }

            Contract.Assume(lineFeed.Offset == carriageReturn.Offset + 1);
            element = new EndOfLine(carriageReturn, lineFeed, context);
            return true;
        }

        /// <summary>TODO </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.crLexer != null);
            Contract.Invariant(this.lfLexer != null);
        }
    }
}