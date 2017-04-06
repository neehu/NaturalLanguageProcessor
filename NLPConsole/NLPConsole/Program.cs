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
            NLP nlp = new NLP();
            nlp.loadConfigurationFile(Convert.ToString(Console.ReadKey()));
            nlp.getMatchedIntetnt("Search Restaraunts Nearby");
        }
    }
}
