using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPConfiguration
{
    public class Class1
    {
        public static string loadConfigurationFile( string filePath)
        {
           return  System.IO.File.ReadAllText(filePath);
        }
    }
}
