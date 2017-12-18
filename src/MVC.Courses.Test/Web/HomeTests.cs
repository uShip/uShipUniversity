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
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl(@"/"));
            WebDriver.Url.ShouldContain("/Home/Status");
        }
    }
}
