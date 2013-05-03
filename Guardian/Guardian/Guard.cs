namespace Guardian
{
    public static class Guard
    {
        static Guard()
        {
            That = new GuardType();
        }

        public static GuardType That { get; private set; }
    }
}