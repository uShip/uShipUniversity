using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Integration.Web
{
    [TestFixture]
    public class StudentTests : SeleniumTest
    {
        public StudentTests() : base("MVC.Courses.Web")
        {

        }

        [Test]
        public void GetAgent_should_return_browser_type()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student/GetAgent"));
            var source = WebDriver.PageSource;
            source.ShouldContain("Chrome");
        }
    }
}
