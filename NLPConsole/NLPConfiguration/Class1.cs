using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPConfiguration
{
public class Intent
{
    [JsonProperty(PropertyName = "verbs")]
    List<string> Verbs { get; set; }
    [JsonProperty(PropertyName = "keywords")]
    List<string> Keywords { get; set; }
    [JsonProperty(PropertyName = "nouns")]
    List<string> Nouns { get; set; }
    List<string> Parameter { get; set; }
    string Action { get; set; }
}
public class NLP
{
    public Intent loadConfigurationFile(string filePath)
    {
        Intent test = JsonConvert.DeserializeObject<Intent>(System.IO.File.ReadAllText(@"C: \Users\Neeharika.Pathuri\Downloads\NLPConfiguration.json"));
        return test;
    }
}

}
