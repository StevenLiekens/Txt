﻿using System.Diagnostics.Contracts;

namespace Text.Scanning.Core
{
    public class SpLexer : Lexer<SpToken>
    {
        public SpLexer(ITextScanner scanner)
            : base(scanner)
        {
            Contract.Requires(scanner != null);
        }

        public override SpToken Read()
        {
            SpToken token;
            if (this.TryRead(out token))
            {
                return token;
            }

            throw new SyntaxErrorException(this.Scanner.GetContext(), "Expected 'SP'");
        }

        public override bool TryRead(out SpToken token)
        {
            var context = this.Scanner.GetContext();
            if (this.Scanner.TryMatch('\u0020'))
            {
                token = new SpToken(context);
                return true;
            }

            token = default(SpToken);
            return false;
        }
    }
}
