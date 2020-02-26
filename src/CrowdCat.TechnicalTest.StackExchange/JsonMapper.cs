using System.Linq;
using CrowdCat.TechnicalTest.Domain;
using Newtonsoft.Json;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class JsonMapper : IJsonMapper
    {
        public QuestionResponse Map(string json)
        {
            QuestionJsonObject questionJsonObject = JsonConvert.DeserializeObject<QuestionJsonObject>(json);

            QuestionResponse questionResponse = new QuestionResponse
            {
                HasMore = questionJsonObject.has_more,
                Questions = questionJsonObject.items.Select(x => new Question(new CreateQuestionDto
                {
                    ViewTotal = x.view_count,
                    Tags = x.tags
                }))
            };

            return questionResponse;
        }
    }
}