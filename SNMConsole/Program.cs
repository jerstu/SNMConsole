using DataGenerator;
using System.Text;

Pattern pattern = new Pattern("AA₵-00000");
var generator = new Generator(pattern.Template);

string input = "";

while (input != "q")
{
    Console.WriteLine(generator.GetRandomSerial());
}