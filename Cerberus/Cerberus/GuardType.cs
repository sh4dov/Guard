using Cerberus.Conditions;

namespace Cerberus
{
    public sealed class GuardType
    {
        internal GuardType()
        {
            Argument = new ArgumentCondition();
            Collection = new CollectionCondition(Argument);
        }

        public ArgumentCondition Argument { get; private set; }

        public CollectionCondition Collection { get; private set; }
    }
}