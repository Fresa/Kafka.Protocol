namespace Kafka.Protocol.Generator.Definitions.FieldExpression
{
    internal abstract class FieldExpressionOperator : FieldExpressionToken
    {
        internal static And And 
            => new And();
        internal static Or Or
            => new Or();
    }
}