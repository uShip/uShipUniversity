using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using NUnit.Framework;

namespace MVC.Courses.Test.Integration
{   
    public abstract class IisServerTestBase
    {
        private const ushort IisPort = 2042;
        private const ushort VisualStudioPort = 50544;

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
            StartIIS();

            Initialize();
        }

        [TearDown]
        public void TestCleanup()
        {
            Cleanup();
            // Ensure IISExpress is stopped
            if (_iisProcess?.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        public abstract void Initialize();
        public abstract void Cleanup();

        private static bool IsVsIisRunning()
        {
            using (var client = new HttpClient())
            {
                var request = client.GetAsync($"http://localhost:{VisualStudioPort}/Home/Status");
                try
                {
                    var response = request.Result;
                    var isOk =  response.IsSuccessStatusCode;
                    response.Dispose();
                    return isOk;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        private void StartIIS()
        {
            _iisProcess = null;
            if (IsVsIisRunning())
            {
                return;
            }

            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = Path.Combine(programFiles,"IIS Express","iisexpress.exe");
            _iisProcess.StartInfo.Arguments = $"/path:\"{applicationPath}\" /port:{IisPort}";
            _iisProcess.Start();
        }

        protected virtual string GetApplicationPath(string applicationName)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;            
            var solutionFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..",".."));
            
            return Path.Combine(solutionFolder, applicationName);
        }

        private ushort CurrentPort => _iisProcess != null ? IisPort : VisualStudioPort;
        public string GetAbsoluteUrl(string relativeUrl)
        {
            return $"http://localhost:{CurrentPort}{(relativeUrl.StartsWith("/") ? "" : "/")}{relativeUrl}";
        }
    }
}