using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NLPConfiguration
{
    public class Intent
    {
        [JsonProperty(PropertyName = "verbs")]
        public List<string> Verbs { get; set; }
        [JsonProperty(PropertyName = "keywords")]
        public List<string> Keywords { get; set; }
        [JsonProperty(PropertyName = "nouns")]
        public List<string> Nouns { get; set; }
        public List<string> Parameter { get; set; }
        string Action { get; set; }
    }
    public class NLP
    {
       public List<Intent> intents { get; set; }
        public void loadConfigurationFile(string filePath)
        {
            intents = JsonConvert.DeserializeObject<List<Intent>>(System.IO.File.ReadAllText(@"C:\Users\Neeharika.Pathuri\Downloads\NLPConfiguration.json")).ToList();  

        }
        public void getMatchedIntetnt(string userInput)
        {
            List<string> words = Regex.Split(userInput, " ").ToList();
            intents.Where(c => c.Keywords.Contains(words.ForEach(items,element=>));
        }
    }
}
