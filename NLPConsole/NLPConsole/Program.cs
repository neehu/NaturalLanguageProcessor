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
            NLP nlp= new NLP();
            Console.WriteLine("Please Enter the file path for Configuration file");
           Console.WriteLine(nlp.loadConfigurationFile(Convert.ToString(Console.ReadKey())));         
        }
    }
}
