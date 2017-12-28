using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace MVC.Courses.Test.Integration
{
    public abstract class IisServerTestBase
    {
        private const int IisPort = 2042;
        private readonly string _applicationName;
        private Process _iisProcess;

        protected IisServerTestBase(string applicationName)
        {
            _applicationName = applicationName;
        }

        [SetUp]
        public void TestInitialize()
        {
            // Start IISExpress
            StartIis();
            Initialize();
        }

        [TearDown]
        public void TestCleanup()
        {
            Cleanup();
            // Ensure IISExpress is stopped
            if (_iisProcess.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        public abstract void Initialize();
        public abstract void Cleanup();

        private void StartIis()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process
            {
                StartInfo =
                {
                    FileName = programFiles + @"\IIS Express\iisexpress.exe",
                    Arguments = $"/path:\"{applicationPath}\" /port:{IisPort}"
                }
            };
            _iisProcess.Start();
        }

        protected virtual string GetApplicationPath(string applicationName)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;            
            var solutionFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..",".."));
            
            return Path.Combine(solutionFolder, applicationName);
        }

        public string GetAbsoluteUrl(string relativeUrl)
        {
            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }
            return $"http://localhost:{IisPort}/{relativeUrl}";
        }
    }
}