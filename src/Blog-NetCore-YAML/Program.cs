using System;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace Blog_NetCore_YAML
{
    public class Program
    {

        private const string YAML_DOCUMENT = @"# An employee record
teachers:
    - name: Rodolfo Langostino
      age: 44
      phoneNumber: +34678901234
    - name: María Rosa Pescanova
      age: 45
      phoneNumber: +34678905678";

        public static void Main(string[] args)
        {
            Console.WriteLine("YAML Sample");
            Console.WriteLine();

            // Read the YAML document
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Reading the YAML document...");
            var stringReader = new StringReader(YAML_DOCUMENT);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE!");

            // Load the stream
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Loading the YAML document...");
            var yaml = new YamlStream();
            yaml.Load(stringReader);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE!");

            // Examine the stream
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Examining the YAML document...");
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DONE!");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Listing all items...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Show the entries
            foreach (var entry in mapping.Children)
            {
                Console.WriteLine(((YamlScalarNode)entry.Key).Value);

                Console.ForegroundColor = ConsoleColor.Magenta;
                var items = (YamlSequenceNode)mapping.Children[new YamlScalarNode("teachers")];
                foreach (YamlMappingNode item in items)
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                        item.Children[new YamlScalarNode("name")],
                        item.Children[new YamlScalarNode("age")],
                        item.Children[new YamlScalarNode("phoneNumber")]
                    );
                }
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
