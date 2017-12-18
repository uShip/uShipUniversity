using System;
using System.Diagnostics;
using System.IO;

using NUnit.Framework;

namespace MVC.Courses.Test.Web
{
    [SetUpFixture]
    public abstract class IISServerTest
    {
        const int IisPort = 2042;
        private readonly string _applicationName;
        private Process _iisProcess;

        protected IISServerTest(string applicationName)
        {
            _applicationName = applicationName;
        }

        [SetUp]
        public void TestInitialize()
        {
            // Start IISExpress
            StartIIS();

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

        private void StartIIS()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, IisPort);
            _iisProcess.Start();
        }

        protected virtual string GetApplicationPath(string applicationName)
        {
            var solutionFolder =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }

        public string GetAbsoluteUrl(string relativeUrl)
        {
            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }
            return String.Format("http://localhost:{0}/{1}", IisPort, relativeUrl);
        }
    }
}