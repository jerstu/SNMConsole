using DataGenerator;
using System.Text;

Pattern pattern = new Pattern("AC-00");


var generator = new Generator(pattern.Template);

generator.Build();
generator.WriteToConsole();