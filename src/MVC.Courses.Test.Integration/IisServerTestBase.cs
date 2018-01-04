using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
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

        [OneTimeSetUp]
        public Task FixtureInitialze()
        {
            // Start IISExpress
            return StartIis();
        }

        [SetUp]
        public void TestInitialize()
        {
            Initialize();
        }

        [OneTimeTearDown]
        public void FixtureCleanup()
        {
            // Ensure IISExpress is stopped
            if (_iisProcess?.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            Cleanup();           
        }

        public abstract void Initialize();
        public abstract void Cleanup();

        private static async Task<bool> IsVsIisRunning()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync($"http://localhost:{VisualStudioPort}/Home/Status"))
                    {
                        return response.IsSuccessStatusCode;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        private async Task StartIis()
        {
            _iisProcess = null;
            if (await IsVsIisRunning())
            {
                return;
            }

            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(programFiles, "IIS Express", "iisexpress.exe"),
                    Arguments = $"/path:\"{applicationPath}\" /port:{IisPort}"
                }
            };
            _iisProcess.Start();
        }

        protected virtual string GetApplicationPath(string applicationName)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;            
            var solutionFolder = Path.GetFullPath(Path.Combine(baseDir, "..", "..",".."));
            
            return Path.Combine(solutionFolder, applicationName);
        }

        private ushort CurrentPort => _iisProcess != null ? IisPort : VisualStudioPort;
        public string GetAbsoluteUrl(string relativeUrl)
        {
            return $"http://localhost:{CurrentPort}{(relativeUrl.StartsWith("/") ? "" : "/")}{relativeUrl}";
        }
    }
}