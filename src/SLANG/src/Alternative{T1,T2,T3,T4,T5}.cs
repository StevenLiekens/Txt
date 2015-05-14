﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Alternative{T1,T2,T3,T4,T5}.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
//   Represents a choice of five alternative elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Represents a choice of five alternative elements.</summary>
    /// <typeparam name="T1">The type of the first alternative element.</typeparam>
    /// <typeparam name="T2">The type of the second alternative element.</typeparam>
    /// <typeparam name="T3">The type of the third alternative element.</typeparam>
    /// <typeparam name="T4">The type of the fourth alternative element.</typeparam>
    /// <typeparam name="T5">The type of the fifth alternative element.</typeparam>
    public class Alternative<T1, T2, T3, T4, T5> : Element
        where T1 : Element where T2 : Element where T3 : Element where T4 : Element where T5 : Element
    {
        /// <summary>The matched alternative element.</summary>
        private readonly Element element;

        /// <summary>The ordinal position of the matched alternative.</summary>
        private readonly int ordinal;

        /// <summary>Initializes a new instance of the <see cref="Alternative{T1,T2,T3,T4,T5}"/> class with a specified alternative.</summary>
        /// <param name="element">The alternative element.</param>
        /// <param name="alternative">A number that indicates which alternative was matched.</param>
        public Alternative(Element element, int alternative)
            : base(element)
        {
            switch (alternative)
            {
                case 1:
                    if (false == element is T1)
                    {
                        throw new ArgumentException("Precondition: element is T1", "element");
                    }

                    break;
                case 2:
                    if (false == element is T2)
                    {
                        throw new ArgumentException("Precondition: element is T2", "element");
                    }

                    break;
                case 3:
                    if (false == element is T3)
                    {
                        throw new ArgumentException("Precondition: element is T3", "element");
                    }

                    break;
                case 4:
                    if (false == element is T4)
                    {
                        throw new ArgumentException("Precondition: element is T4", "element");
                    }

                    break;
                case 5:
                    if (false == element is T5)
                    {
                        throw new ArgumentException("Precondition: element is T5", "element");
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException("alternative", alternative, "Precondition: 1 <= alternative <= 5");
            }

            this.element = element;
            this.ordinal = alternative;
        }

        /// <summary>Gets the matched alternative element.</summary>
        public Element Element
        {
            get
            {
                Debug.Assert(this.element != null, "this.element != null");
                return this.element;
            }
        }

        /// <summary>Gets the ordinal position of the matched alternative.</summary>
        public int Ordinal
        {
            get
            {
                return this.ordinal;
            }
        }
    }
}