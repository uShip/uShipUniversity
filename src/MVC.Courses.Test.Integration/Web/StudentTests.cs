using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
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
        public void GetAgent_should_return_user_agent()
        {
            var userAgent = "Chrome";

            WebDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Student/GetAgent"));
            WebDriver.PageSource.ShouldContain(userAgent);
        }
    }
}
