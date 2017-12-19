using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Integration.Web
{
    [TestFixture(Category = "Selenium")]
    public class HomeTests : SeleniumTest
    {
        public HomeTests() : base("MVC.Courses.WEB") { }

        [TestCase]
        public void Home_index_should_redirect_to_status()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/"));
            WebDriver.Url.ShouldContain("localhost");
        }

        [TestCase]
        public void GiveMeJson_should_return_json()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Home/givemejson?requestObject=headers"));
            var source = WebDriver.PageSource;
            source.ShouldNotBeEmpty();
        }
    }
}
