﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sequence{T1,T2,T3,T4,T5,T6,T7,T8,T9,T10}.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
//   Represents a sequence of ten elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Represents a sequence of ten elements.</summary>
    /// <typeparam name="T1">The type of the first element in the sequence.</typeparam>
    /// <typeparam name="T2">The type of the second element in the sequence.</typeparam>
    /// <typeparam name="T3">The type of the third element in the sequence.</typeparam>
    /// <typeparam name="T4">The type of the fourth element in the sequence.</typeparam>
    /// <typeparam name="T5">The type of the fifth element in the sequence.</typeparam>
    /// <typeparam name="T6">The type of the sixth element in the sequence.</typeparam>
    /// <typeparam name="T7">The type of the seventh element in the sequence.</typeparam>
    /// <typeparam name="T8">The type of the eighth element in the sequence.</typeparam>
    /// <typeparam name="T9">The type of the ninth element in the sequence.</typeparam>
    /// <typeparam name="T10">The type of the tenth element in the sequence.</typeparam>
    public class Sequence<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : Element
        where T1 : Element
        where T2 : Element
        where T3 : Element
        where T4 : Element
        where T5 : Element
        where T6 : Element
        where T7 : Element
        where T8 : Element
        where T9 : Element
        where T10 : Element
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T1 element1;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T10 element10;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T2 element2;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T3 element3;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T4 element4;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T5 element5;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T6 element6;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T7 element7;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T8 element8;

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
            Justification = "Reviewed. Suppression is OK here.")]
        private readonly T9 element9;

        /// <summary>Initializes a new instance of the <see cref="Sequence{T1,T2,T3,T4,T5,T6,T7,T8,T9,T10}"/> class with a specified sequence of elements.</summary>
        /// <param name="element1">The first element in the sequence.</param>
        /// <param name="element2">The second element in the sequence.</param>
        /// <param name="element3">The third element in the sequence.</param>
        /// <param name="element4">The fourth element in the sequence.</param>
        /// <param name="element5">The fifth element in the sequence.</param>
        /// <param name="element6">The sixth element in the sequence.</param>
        /// <param name="element7">The seventh element in the sequence.</param>
        /// <param name="element8">The eighth element in the sequence.</param>
        /// <param name="element9">The ninth element in the sequence.</param>
        /// <param name="element10">The tenth element in the sequence.</param>
        /// <param name="context">The object that describes the context in which the text appears.</param>
        public Sequence(
            T1 element1, 
            T2 element2, 
            T3 element3, 
            T4 element4, 
            T5 element5, 
            T6 element6, 
            T7 element7, 
            T8 element8, 
            T9 element9, 
            T10 element10, 
            ITextContext context)
            : base(
                string.Concat(
                    element1, 
                    element2, 
                    element3, 
                    element4, 
                    element5, 
                    element6, 
                    element7, 
                    element8, 
                    element9, 
                    element10), 
                context)
        {
            if (element1 == null)
            {
                throw new ArgumentNullException("element1", "Precondition: element1 != null");
            }

            if (element2 == null)
            {
                throw new ArgumentNullException("element2", "Precondition: element2 != null");
            }

            if (element3 == null)
            {
                throw
                    new ArgumentNullException("element3", "Precondition: element3 != null");
            }
            if (element4 == null)
            {
                throw new ArgumentNullException("element4", "Precondition: element4 != null");
            }

            if (element5 == null)
            {
                throw new ArgumentNullException("element5", "Precondition: element5 != null");
            }

            if (element6 == null)
            {
                throw new ArgumentNullException("element6", "Precondition: element6 != null");
            }

            if (element7 == null)
            {
                throw new ArgumentNullException("element7", "Precondition: element7 != null");
            }

            if (element8 == null)
            {
                throw new ArgumentNullException("element8", "Precondition: element8 != null");
            }

            if (element9 == null)
            {
                throw new ArgumentNullException("element9", "Precondition: element9 != null");
            }

            if (element10 == null)
            {
                throw new ArgumentNullException("element10", "Precondition: element10 != null");
            }

            this.element1 = element1;
            this.element2 = element2;
            this.element3 = element3;
            this.element4 = element4;
            this.element5 = element5;
            this.element6 = element6;
            this.element7 = element7;
            this.element8 = element8;
            this.element9 = element9;
            this.element10 = element10;
        }

        /// <summary>Gets the first element in the sequence.</summary>
        public T1 Element1
        {
            get
            {
                Debug.Assert(this.element1 != null, "this.element1 != null");
                return this.element1;
            }
        }

        /// <summary>Gets the second element in the sequence.</summary>
        public T2 Element2
        {
            get
            {
                Debug.Assert(this.element2 != null, "this.element2 != null");
                return this.element2;
            }
        }

        /// <summary>Gets the third element in the sequence.</summary>
        public T3 Element3
        {
            get
            {
                Debug.Assert(this.element3 != null, "this.element3 != null");
                return this.element3;
            }
        }

        /// <summary>Gets the fourth element in the sequence.</summary>
        public T4 Element4
        {
            get
            {
                Debug.Assert(this.element4 != null, "this.element4 != null");
                return this.element4;
            }
        }

        /// <summary>Gets the fifth element in the sequence.</summary>
        public T5 Element5
        {
            get
            {
                Debug.Assert(this.element5 != null, "this.element5 != null");
                return this.element5;
            }
        }

        /// <summary>Gets the sixth element in the sequence.</summary>
        public T6 Element6
        {
            get
            {
                Debug.Assert(this.element6 != null, "this.element6 != null");
                return this.element6;
            }
        }

        /// <summary>Gets the seventh element in the sequence.</summary>
        public T7 Element7
        {
            get
            {
                Debug.Assert(this.element7 != null, "this.element7 != null");
                return this.element7;
            }
        }

        /// <summary>Gets the eighth element in the sequence.</summary>
        public T8 Element8
        {
            get
            {
                Debug.Assert(this.element8 != null, "this.element8 != null");
                return this.element8;
            }
        }
        /// <summary>Gets the ninth element in the sequence.</summary>
        public T9 Element9
        {
            get
            {
                Debug.Assert(this.element9 != null, "this.element9 != null");
                return this.element9;
            }
        }

        /// <summary>Gets the tenth element in the sequence.</summary>
        public T10 Element10
        {
            get
            {
                Debug.Assert(this.element10 != null, "this.element10 != null");
                return this.element10;
            }
        }
    }
}