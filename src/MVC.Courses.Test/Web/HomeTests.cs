using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Web
{
    [TestFixture(Category = "Selenium")]
    public class HomeTests : SeleniumTest
    {
        public HomeTests() : base("MVC.Courses.WEB") { }

        [TestCase]
        public void Home_index_should_redirect_to_status()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/"));
            WebDriver.Url.ShouldStartWith("localhost");
        }

        [TestCase]
        public void GiveMeJson_should_return_json()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Home/givemejson?requestObject=headers"));
            var source = WebDriver.PageSource;
            source.ShouldContain("Connection");
            source.ShouldContain("Accept-Encoding");
            source.ShouldContain("Accept-Language");
            source.ShouldContain("User-Agent");
            source.ShouldContain("Host");
        }
    }
}
