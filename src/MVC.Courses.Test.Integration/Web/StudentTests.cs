using System;
using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Integration.Web
{
    [TestFixture(Category = "Selenium")]
    public class StudentTests : SeleniumTest
    {
        public StudentTests() : base("MVC.Courses.WEB") { }

        [TestCase]
        public void Student_index_should_redirect_to_getBrowser()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student"));
            var url = WebDriver.Url;
            Console.WriteLine($"Url: {url}");
            url.ShouldContain("Student");
        }

        [TestCase]
        public void Student_GetAgent_Should_return_Chrome()
        {
            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student/getAgent"));
            var source = WebDriver.PageSource;
            Console.WriteLine($"Webdriver.PageSource: {source}");
            source.ShouldContain("Chrome");
        }
    }
}
