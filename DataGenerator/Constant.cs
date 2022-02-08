using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    // Constant is a character in the serial sequence that does not change, such as the hyphen in "XG-229"
    // The generator or pattern constructor will pass this character into the Constant constructor
    // The Increment method will not change the character, but will always return true so the
    // generator.build algorithm advances to the next position
    class Constant : ICharacter
    {
        public char C { get; set; }
        public Constant(char c)
        {
            C = c;
        }
        public bool Increment()
        {
            return true;
        }

        public override string ToString()
        {
            return C.ToString();
        }

        public void GetRandomValue()
        {
            // No Implementation Necessary
        }
    }
}
