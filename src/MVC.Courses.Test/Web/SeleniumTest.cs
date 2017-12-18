using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MVC.Courses.Test.Web
{
    public abstract class SeleniumTest : IISServerTest
    {
        private ChromeDriver _chromeDriver;

        protected IWebDriver WebDriver
        {
            get { return _chromeDriver; }
        }

        protected SeleniumTest(string appName) : base(appName) { }


        public override void Initialize()
        {
            _chromeDriver = new ChromeDriver();
        }

        public override void Cleanup()
        {
            _chromeDriver.Dispose();
        }
    }
}