﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DigitLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG.Core
{
    using System;

    public class DigitLexer : Lexer<Digit>
    {
        private readonly ILexer<Element> digitValueRangeLexer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digitValueRangeLexer">%x30-39</param>
        public DigitLexer(ILexer<Element> digitValueRangeLexer)
            : base("DIGIT")
        {
            if (digitValueRangeLexer == null)
            {
                throw new ArgumentNullException("digitValueRangeLexer", "Precondition: digitValueRangeLexer != null");
            }

            this.digitValueRangeLexer = digitValueRangeLexer;
        }

        public override bool TryRead(ITextScanner scanner, out Digit element)
        {
            Element value;
            if (this.digitValueRangeLexer.TryRead(scanner, out value))
            {
                element = new Digit(value);
                return true;
            }

            element = default(Digit);
            return false;
        }
    }
}