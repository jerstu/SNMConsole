using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DataGenerator.Generator takes a "sequence" template which is a string that defines how a serial number is generated


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

        private string ICharacterArrayToString()
        {
            StringBuilder s = new();
            foreach (var character in CurrentValue)
            {
                s.Append(character);
            }
            return s.ToString();
        }


        public List<string> Build(bool randomized = false)
        {
            SerialList.Add(ICharacterArrayToString());
            for (var position = CurrentValue.Length - 1; position >= 0;)
            {
                if (CurrentValue[position].Increment())
                {
                    position--;
                }
                else
                {
                    SerialList.Add(ICharacterArrayToString());
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

        public void WriteToConsole()
        {
            foreach(var item in SerialList)
            {
                Console.WriteLine(item);
            }
        }

        //public void RandomWriteToCSVFile(string outFile = "randommaster.csv")
        //{
        //    using (StreamWriter outputFile = new StreamWriter(outFile))
        //    {
        //        foreach (var item in RandomPatternMasterList)
        //        {
        //            outputFile.WriteLine(item);
        //        }
        //    }
        //}



    }
}
