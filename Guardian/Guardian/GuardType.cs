namespace Guardian
{
    public sealed class GuardType
    {
        internal GuardType()
        {
            Argument = new Condition();
        }

        public Condition Argument { get; set; }
    }
}