using System.Collections.Generic;

namespace CrowdCat.TechnicalTest.ConsoleApp.UnitTests
{
    public class TestAppOutput : IAppOutput
    {
        public List<string> Outputs { get; } = new List<string>();

        public void WriteLine(string outputString) => Outputs.Add(outputString);
    }
}