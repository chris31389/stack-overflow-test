using System;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class AppOutput : IAppOutput
    {
        public void WriteLine(string outputString) => Console.WriteLine(outputString);
    }
}