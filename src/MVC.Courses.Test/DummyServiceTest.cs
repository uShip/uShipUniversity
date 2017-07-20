using Iteration.Zero.Core;
using NUnit.Framework;
using Should;

namespace Iteration.Zero.Test
{
    [TestFixture]
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
