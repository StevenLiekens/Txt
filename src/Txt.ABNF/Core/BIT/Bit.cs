﻿using System.Collections.Generic;
using JetBrains.Annotations;
using Txt.Core;

namespace Txt.ABNF.Core.BIT
{
    public class Bit : Element
    {
        public Bit([NotNull] Element element)
            : base(element)
        {
        }

        public Bit([NotNull] string terminals, [NotNull] ITextContext context)
            : base(terminals, context)
        {
        }

        public Bit([NotNull] string sequence, [NotNull] IList<Element> elements, [NotNull] ITextContext context)
            : base(sequence, elements, context)
        {
        }
    }
}
