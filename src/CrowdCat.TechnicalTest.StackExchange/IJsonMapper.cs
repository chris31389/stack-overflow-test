namespace CrowdCat.TechnicalTest.StackExchange
{
    public interface IJsonMapper
    {
        QuestionResponse Map(string json);
    }
}