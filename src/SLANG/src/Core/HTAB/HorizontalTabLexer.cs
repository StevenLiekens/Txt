﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HorizontalTabLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG.Core
{
    using System;

    public class HorizontalTabLexer : Lexer<HorizontalTab>
    {
        private readonly ILexer horizontalTabTerminalLexer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="horizontalTabTerminalLexer">%x09</param>
        public HorizontalTabLexer(ILexer horizontalTabTerminalLexer)
            : base("HTAB")
        {
            if (horizontalTabTerminalLexer == null)
            {
                throw new ArgumentNullException("horizontalTabTerminalLexer", "Precondition: horizontalTabTerminalLexer != null");
            }

            this.horizontalTabTerminalLexer = horizontalTabTerminalLexer;
        }

        /// <inheritdoc />
        public override bool TryRead(ITextScanner scanner, out HorizontalTab element)
        {
            Element result;
            if (this.horizontalTabTerminalLexer.TryReadElement(scanner, out result))
            {
                element = new HorizontalTab(result);
                return true;
            }
            
            element = default(HorizontalTab);
            return false;
        }
    }
}