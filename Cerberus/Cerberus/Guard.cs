namespace Cerberus
{
    public static partial class Guard
    {
        static Guard()
        {
            That = new GuardType();
        }

        public static GuardType That { get; private set; }
    }
}