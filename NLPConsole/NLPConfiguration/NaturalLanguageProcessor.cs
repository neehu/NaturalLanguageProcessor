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

        [JsonProperty(PropertyName = "entities")]
        public List<Entity> Entities { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }
    }

    public class Entity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "values")]
        public List<string> Values { get; set; }
    }

    public class IntentResult
    {
        public Dictionary<string, List<string>> Parameters { get; set; }
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
            {
                var matchingEntity = matchingIntents.FirstOrDefault();
                var parameters = ProcessForEntities(matchingEntity.Entities, words);

                return new IntentResult()
                {
                    Action = matchingEntity.Action,
                    Parameters = parameters
                };
            }
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

        private Dictionary<string, List<string>> ProcessForEntities(List<Entity> entities, List<string> words)
        {
            Dictionary<string, List<string>> parameters = new Dictionary<string, List<string>>();
            var priceRange = ProcessForPriceRange(string.Join(" ", words));
            List<string> prices = new List<string>();
            prices.Add(priceRange);
            entities.ForEach(entity => {
                var matches = from w in words
                              where entity.Values.Contains(w)
                                     select w;
               
               
                parameters.Add(entity.Name, matches.ToList());
                if(entity.Name== "pricerange")
                parameters[entity.Name].Add(priceRange);
             

            });
            


            if (parameters.Count() > 0)
                return parameters;
            else
                return null;
        }
        private string ProcessForPriceRange(string words)
        {
            var firstPriceValue = Regex.Match(words, @"between [0-9][0-9] to [0-9][0-9]");
            return firstPriceValue.Value;
        }

    }
}
