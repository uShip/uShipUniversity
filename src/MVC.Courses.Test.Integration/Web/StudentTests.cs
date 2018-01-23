using NUnit.Framework;
using OpenQA.Selenium;
using Should;

namespace MVC.Courses.Test.Integration.Web
{
    [TestFixture(Category = "Selenium")]
    public class StudentTests : SeleniumTest
    {
        public StudentTests() : base("MVC.Courses.WEB") { }

        [TestCase]
        public void Student_GetAgent_should_return_Chrome()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student/GetAgent"));
            var output = WebDriver.FindElement(By.TagName("pre")).Text;
            output.ShouldEqual("\"Chrome\"");
        }
    }
}
