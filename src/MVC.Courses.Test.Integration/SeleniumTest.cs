using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MVC.Courses.Test.Integration
{
    public abstract class SeleniumTest : IisServerTestBase
    {
        private ChromeDriver _chromeDriver;

        protected IWebDriver WebDriver => _chromeDriver;

        protected SeleniumTest(string appName) : base(appName) { }


        public override void Initialize()
        {
            var options = new ChromeOptions();
//            options.AddArgument("--headless");
//            options.AddArgument("--disable-gpu");
//            options.AddArgument("--no-sandbox");
            _chromeDriver = new ChromeDriver(options);
        }

        public override void Cleanup()
        {
            _chromeDriver.Dispose();
        }
    }
}