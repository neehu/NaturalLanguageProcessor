
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NLPConfiguration
{
    public class IntentConfiguration
    {
        [JsonProperty(PropertyName = "intentName")]
        public string IntentName { get; set; }

        [JsonProperty(PropertyName = "verbs")]
        public List<string> Verbs { get; set; }

        [JsonProperty(PropertyName = "keywords")]
        public List<string> Keywords { get; set; }

        [JsonProperty(PropertyName = "nouns")]
        public List<string> Nouns { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }
    }

    public class IntentResult
    {
        public List<string> Parameter { get; set; }
        public string Action { get; set; }
    }

    public class NaturalLanguageProcessor
    {
        public List<IntentConfiguration> RulesConfigurations { get; private set; }

        public void LoadConfigurationFile(string filePath)
        {
            RulesConfigurations = JsonConvert.DeserializeObject<List<IntentConfiguration>>(File.ReadAllText(filePath)).ToList();
        }

        public IntentResult GetMatchingIntent(string speechText)
        {
            List<string> words = speechText.Split(' ').ToList();

            //For each config
            var matchingIntents = from i in this.RulesConfigurations
                                  where ProcessForMatch(i, words)
                                  select i;

            if (matchingIntents.Any())
                return new IntentResult() { Action = matchingIntents.FirstOrDefault().Action, Parameter = null };
            else
                return null;
        }

        private bool ProcessForMatch(IntentConfiguration intentConfiguration, List<string> words)
        {
            bool result = false;

            if (ProcessForKeywords(intentConfiguration.Keywords, words))
                if (ProcessForKeywords(intentConfiguration.Verbs, words))
                    result = true;

            return result;
        }

        private bool ProcessForKeywords(List<string> keywords, List<string> words)
        {
            bool result = false;

            var matchingWords = from w in words
                                where keywords.Contains(w)
                                select w;

            if (matchingWords.Any())
                result = true;

            return result;
        }
    }
}
