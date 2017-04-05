using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPConfiguration
{
    public class Intent
    {
<<<<<<< HEAD
        List<string> Verbs { get; set; }
        List<string> Keywords { get; set; }
        List<string> Nouns { get; set; }
        List<string> Parameter { get; set; }
        string Action { get; set; }
=======
        public static string loadConfigurationFile( string filePath)
        {
           return  System.IO.File.ReadAllText(filePath);
        }
>>>>>>> fa51f2cbf84d6192ae64ecc7c8a49fd0f7fd20a2
    }
    
}
