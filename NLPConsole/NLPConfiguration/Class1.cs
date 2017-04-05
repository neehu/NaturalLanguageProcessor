using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPConfiguration
{
    public class Intent
    {
        List<string> Verbs { get; set; }
        List<string> Keywords { get; set; }
        List<string> Nouns { get; set; }
        List<string> Parameter { get; set; }
        string Action { get; set; }
    }
    
}
