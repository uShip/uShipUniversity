using Iteration.Zero.Core;

namespace Iteration.Zero.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new DummyService();
            System.Console.WriteLine("Iteration Zero ... Service.Foo(): {0}", service.Foo());
            System.Console.ReadLine();
        }
    }
}
