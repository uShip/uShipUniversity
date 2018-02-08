using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Integration.Web
{
    [TestFixture(Category = "Selenium")]
    public class StudentTests : SeleniumTest
    {
        public StudentTests() : base("MVC.Courses.WEB") { }

        [TestCase]
        public void student_getAgent_should_return_chrome()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student/GetAgent"));
            WebDriver.PageSource.ShouldContain("\\\"Browser\\\":\\\"Chrome\\\"");
        }

    }
}
