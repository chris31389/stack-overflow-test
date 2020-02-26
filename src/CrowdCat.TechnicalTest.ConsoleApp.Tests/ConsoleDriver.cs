using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrowdCat.TechnicalTest.ConsoleApp.Tests
{
    /// <summary>
    /// https://www.codeproject.com/Articles/17652/How-to-Test-Console-Applications
    /// </summary>
    public class ConsoleDriver
    {
        private TextWriter _normalConsoleOutput;
        private StringWriter _testingConsoleOutput;
        private StringBuilder _testingStringBuilder;
        public string DateInputParameter { get; set; }

        public string Output => _testingConsoleOutput.ToString();

        public async Task Run()
        {
            StartCapturingConsoleOutput();
            await RunConsoleApplication(DateInputParameter);
            StopCapturingConsoleOutput();
        }

        private static async Task RunConsoleApplication(params string[] arguments) => await TestProgram.Main(arguments);

        private void StartCapturingConsoleOutput()
        {
            // Set current folder to testing folder
            string assemblyCodeBase = Assembly.GetExecutingAssembly().CodeBase;

            // GetAsync directory name
            string dirName = Path.GetDirectoryName(assemblyCodeBase);

            // remove URL-prefix if it exists
            if (dirName.StartsWith("file:\\"))
                dirName = dirName.Substring(6);

            // set current folder
            Environment.CurrentDirectory = dirName;

            // Initialize string builder to replace console
            _testingStringBuilder = new StringBuilder();
            _testingConsoleOutput = new StringWriter(_testingStringBuilder);

            // swap normal output console with testing console - to reuse 
            // it later
            _normalConsoleOutput = Console.Out;
            Console.SetOut(_testingConsoleOutput);
        }

        private void StopCapturingConsoleOutput()
        {
            // set normal output stream to the console
            Console.SetOut(_normalConsoleOutput);
        }
    }
}