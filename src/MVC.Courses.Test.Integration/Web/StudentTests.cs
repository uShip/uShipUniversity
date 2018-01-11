using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Integration.Web
{
    [TestFixture(Category = "Selenium")]
    public class StudentTests : SeleniumTest
    {
        public StudentTests() : base("MVC.Courses.WEB")
        {
        }

        [TestCase]
        public void Student_index_should_redirect_to_GetAgent()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/student"));
            WebDriver.Url.ShouldContain("/Student/GetAgent");
        }

        [TestCase]
        public void GetAgent_should_return_json()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student/GetAgent"));
            var source = WebDriver.PageSource;
            source.ShouldNotBeEmpty();
        }
    }
}