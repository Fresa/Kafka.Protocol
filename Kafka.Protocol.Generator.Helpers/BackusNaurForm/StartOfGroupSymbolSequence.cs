﻿namespace Kafka.Protocol.Generator.Helpers.BackusNaurForm
{
    internal class StartOfGroupSymbolSequence : OperatorSymbolSequence
    {
        internal StartOfGroupSymbolSequence()
            : base(new SymbolReference("("))
        {
        }

        internal override int Precedence => -1;
    }
}