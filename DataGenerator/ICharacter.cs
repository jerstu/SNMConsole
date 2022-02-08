﻿namespace DataGenerator
{
    public interface ICharacter
    {
        // An ICharacter implementaion has an Increment() method which increments the Character (such as A -> B or 3 -> 4)
        // The Increment() should return true if it has reached its maximum value and "rolled over" to the minimum (Z -> A or 9 -> 0)
        // This signals to the generator that the next position or "place value" must also be incremented before returning to position ^1

        // All ICharacters should Implement a GetRandomValue() method to allow the DataGenerator to create a Random Serial

        // All ICharacters should Implement a ToString() as an overide for that datatype.
        bool Increment();
        void GetRandomValue();
        string ToString();
    }
}
