using Moq;
using MVC.Courses.Web.Controllers;
using NUnit.Framework;
using Should;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Courses.Test.Unit.Unit
{
    [TestFixture(Category = "UnitTest")]
    public class StudentControllerTest
    {
        [Test]
        public void student_getAgent_should_return_browser_name()
        {
            var userAgent = "Firefox";

            var request = new Mock<HttpRequestBase>();
            request.SetupGet(x => x.Browser.Browser).Returns(userAgent);

            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);

            var studentController = new StudentController();
            studentController.ControllerContext =
                new System.Web.Mvc.ControllerContext(context.Object, new RouteData(), studentController);

            var result = studentController.GetAgent();

            var jsonResult = result as JsonResult;
            Assert.AreEqual(userAgent, jsonResult.Data);

            //Resources used
            //https://stackoverflow.com/questions/970198/how-to-mock-the-request-on-controller-in-asp-net-mvc
            //https://stackoverflow.com/questions/9263457/how-do-i-make-a-unit-test-to-test-a-method-that-checks-request-headers
        }
    }
}
