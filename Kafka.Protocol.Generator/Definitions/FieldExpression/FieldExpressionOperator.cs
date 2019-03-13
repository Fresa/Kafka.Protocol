namespace Kafka.Protocol.Generator.Definitions.FieldExpression
{
    internal abstract class FieldExpressionOperator : FieldExpressionToken
    {
        protected FieldExpressionOperator(FieldExpressionOperatorName name)
        {
            Name = name;
        }

        internal override FieldExpressionType ExpressionType => 
            FieldExpressionType.Operator;

        internal FieldExpressionOperatorName Name { get; }

        internal static And And 
            => new And();
        internal static Or Or
            => new Or();
    }
}