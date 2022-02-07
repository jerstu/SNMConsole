namespace DataGenerator
{
    class Number : ICharacter
    {
        public int N;

        public Number(int initialValue = 0)
        {
            N = initialValue;
        }

        public void GetRandomValue()
        {
            Random random = new();
            N = random.Next(0,9);
        }

        public bool Increment()
        {
            N = (N + 1) % 10;
            return N == 0;
        }

        public override string ToString()
        {
            return N.ToString();
        }
    }
}
