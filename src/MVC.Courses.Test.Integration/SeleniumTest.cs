using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MVC.Courses.Test
{
    public abstract class SeleniumTest : IisServerTestBase
    {
        private ChromeDriver _chromeDriver;

        protected IWebDriver WebDriver
        {
            get { return _chromeDriver; }
        }

        protected SeleniumTest(string appName) : base(appName) { }


        public override void Initialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            _chromeDriver = new ChromeDriver(options);
        }

        public override void Cleanup()
        {
            _chromeDriver.Dispose();
        }
    }
}