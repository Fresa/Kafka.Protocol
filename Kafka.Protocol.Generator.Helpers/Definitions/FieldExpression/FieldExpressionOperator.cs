﻿namespace Kafka.Protocol.Generator.Helpers.Definitions.FieldExpression
{
    public abstract class FieldExpressionOperator : FieldExpressionToken
    {
        internal static And And 
            => new And();
        internal static Or Or
            => new Or();
    }
}