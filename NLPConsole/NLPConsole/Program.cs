
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
            nlp.LoadConfigurationFile(@"C:\Users\Harshvardhan.Poddar\Documents\NaturalLanguageProcessor\NLPConfiguration.json");

            while (true)
            {
                Console.WriteLine("Enter your Input");
                string userSearch = Console.ReadLine();
                var intentResult = nlp.GetMatchingIntent(userSearch);


                if (intentResult != null)
                    Console.Write("Awesome, I will get it done. Action: " + intentResult.Action);
                else
                    Console.Write("Sorry, I do not understand that.");
                Console.ReadLine();
            }
        }
    }
}
