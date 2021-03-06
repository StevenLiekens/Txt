﻿using JetBrains.Annotations;

namespace Txt.Core
{
    /// <summary>Provides the interface for factory classes that create lexers for elements of the specified type.</summary>
    /// <typeparam name="T">The type of the element that represents the lexer rule.</typeparam>
    public interface ILexerFactory<out T>
        where T : Element
    {
        /// <summary>
        ///     Initializes a new instance of a class that implements the <see cref="ILexer{TElement}" /> interface of the
        ///     specified type.
        /// </summary>
        /// <returns>An instance of a class that implements <see cref="ILexer{TElement}" /> of the specified type.</returns>
        [NotNull]
        ILexer<T> Create();

        [NotNull]
        ILexerFactory<T> Singleton();
    }
}
