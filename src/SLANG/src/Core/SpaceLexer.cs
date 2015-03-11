﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpaceLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
//   TODO
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG.Core
{
    /// <summary>TODO </summary>
    public class SpaceLexer : Lexer<Space>
    {
        /// <summary>Initializes a new instance of the <see cref="SpaceLexer"/> class.</summary>
        public SpaceLexer()
            : base("SP")
        {
        }

        /// <inheritdoc />
        public override bool TryRead(ITextScanner scanner, out Space element)
        {
            if (scanner.EndOfInput)
            {
                element = default(Space);
                return false;
            }

            var context = scanner.GetContext();
            if (scanner.TryMatch('\u0020'))
            {
                element = new Space(context);
                return true;
            }

            element = default(Space);
            return false;
        }
    }
}