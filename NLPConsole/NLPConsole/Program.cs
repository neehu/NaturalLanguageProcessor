
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPConfiguration;

namespace NLPConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            NaturalLanguageProcessor nlp = new NaturalLanguageProcessor();
            nlp.LoadConfigurationFile(@"C:\Users\Neeharika.Pathuri\Documents\NaturalLanguageProcessor\NLPConfiguration.json");

            while (true)
            {
                Console.WriteLine("Enter your Input");
                string userSearch = Console.ReadLine();
                var intentResult = nlp.GetMatchingIntent(userSearch);


                if (intentResult != null)
                {
                    Console.WriteLine("Awesome, I will get it done.");
                    Console.WriteLine("Action: " + intentResult.Action);
                    foreach (var paramter in intentResult.Parameters)
                    {
                        Console.WriteLine("Parameter Name: " + paramter.Key);
                        Console.WriteLine("Parameter Values: " + string.Join(", ", paramter.Value));
                    }
                }
                else
                    Console.Write("Sorry, I do not understand that.");
                Console.ReadLine();
            }
        }
    }
}
