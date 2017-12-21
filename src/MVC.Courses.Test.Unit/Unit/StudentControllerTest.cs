using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using MVC.Courses.Web.Controllers;
using NUnit.Framework;

namespace MVC.Courses.Test.Unit.Unit
{
    [TestFixture(Category = "UnitTest")]
    public class StudentControllerTest
    {
        [Test]
        public void GetAgent_should_return_browser_name()
        {
            //arrange
            var userAgent = "IE6 :(";

            var request = new Mock<HttpRequestBase>();
            request.SetupGet(r => r.Browser.Browser).Returns(userAgent);

            var context = new Mock<HttpContextBase>();
            context.SetupGet(c => c.Request).Returns(request.Object);

            var studentController = new StudentController();
            studentController.ControllerContext =
                new ControllerContext(context.Object, new RouteData(), studentController);

            //act
            var result = studentController.GetAgent();

            //assert
            var jsonResult = result as JsonResult;
            Assert.AreEqual(userAgent, jsonResult.Data);

        }
    }
}
