using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

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

        public void Run()
        {
            StartCapturingConsoleOutput();
            RunConsoleApplication(DateInputParameter);
            StopCapturingConsoleOutput();
        }

        private static void RunConsoleApplication(params string[] arguments) => Program.Main(arguments);

        private void StartCapturingConsoleOutput()
        {
            // Set current folder to testing folder
            string assemblyCodeBase = Assembly.GetExecutingAssembly().CodeBase;

            // Get directory name
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