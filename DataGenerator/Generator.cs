using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DataGenerator.Generator takes a "sequence" template which is a string that defines how a serial number is generated
// DataGenerator has no public properties. Only a handful of methods which other utilities can utilize to create the type of serials they need.


namespace DataGenerator
{
    public class Generator
    {
        private List<string> SerialList { get; set; }
        private ICharacter[] CurrentValue { get; set; }

        public Generator(ICharacter[] initialValue)
        {
            SerialList = new List<string>();
            CurrentValue = initialValue;
        }

        private string CurrentValueToString()
        {
            StringBuilder s = new();
            foreach (var character in CurrentValue)
            {
                s.Append(character);
            }
            return s.ToString();
        }


        public List<string> BuildAllValues(bool randomized = false)
        {
            SerialList.Add(CurrentValueToString());
            for (var position = CurrentValue.Length - 1; position >= 0;)
            {
                if (CurrentValue[position].Increment())
                {
                    position--;
                }
                else
                {
                    SerialList.Add(CurrentValueToString());
                    position = CurrentValue.Length - 1;
                }
            }
            if (randomized)
            {
                return SerialList.OrderBy(o => Guid.NewGuid()).ToList();
            }
            else
            {
                return SerialList;
            }
        }

        public void WriteToCSVFile(string outFile = "testbank.csv")
        {
            using StreamWriter outputFile = new(outFile);
            foreach (var item in SerialList)
            {
                outputFile.WriteLine(item);
            }
        }

        public void WriteAllToConsole()
        {
            foreach(var item in SerialList)
            {
                Console.WriteLine(item);
            }
        }

        public string GetRandomSerial()
        {
            foreach (ICharacter character in CurrentValue)
            {
                character.GetRandomValue();
            }
            return CurrentValueToString();
        }
    }
}
