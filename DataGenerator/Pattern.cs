using DataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class Pattern
    {
        public ICharacter[] Template { get; set; }

        public Pattern(string templateString)
        {
            Template = ParseStringToSequence(templateString);
        }
        public Pattern(ICharacter[] template)
        {
            Template = template;
        }
        private static ICharacter[] ParseStringToSequence(string templateString)
        {
            var characterList = new List<ICharacter>();
            

            for (int i = 0; i < templateString.Length; i++)
            {
                switch (templateString[i])
                {
                    case '0':
                        characterList.Add(new Number());
                        break;
                    case 'A':
                        characterList.Add(new Letter());
                        break;
                    case '₵':
                        characterList.Add(new Constant(templateString[i + 1]));
                        break;
                }
            }
            return characterList.ToArray();
        }
    }
}
