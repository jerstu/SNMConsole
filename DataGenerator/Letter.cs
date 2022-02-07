﻿namespace DataGenerator
{
    class Letter : ICharacter
    {
        public char L { get; set; }

        public Letter()
        {
            L = 'A';
        }

        public bool Increment()
        {
            if (L + 1 == '[') L = 'A';
            else L++;
            return L == 'A';
        }

        public override string ToString()
        {
            return L.ToString();
        }

        public void GetRandomValue()
        {
            Random random = new();
            L = (char)random.Next('A', 'Z');
        }
    }
}
