using Iteration.Zero.Core;
using NUnit.Framework;
using Should;

namespace MVC.Courses.Test.Unit
{
    [TestFixture(Category = "UnitTest")]
    public class DummyServiceTest
    {
        [Test]
        public void foo_should_return_bar()
        {
            var service = new DummyService();
            service.Foo().ShouldEqual("bar");
        }
    }
}
