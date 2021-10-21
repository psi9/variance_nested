using System;

namespace nested2
{
    public interface IGlavniy
    {
        int Field { get; }
    }
    public class Factory
    {
        private int Closed { get; set; } = 10;

        private class Fabrichniy : IGlavniy
        {
            public int Field { get; set; }
            public Fabrichniy(Factory factory)
            {
                Field = factory.Closed;
            }
            public Fabrichniy() { 
            }
        }

        public IGlavniy NewFabrichniy(int value) {
            return new Fabrichniy { Field = value };
        }
        public IGlavniy NewFabrichniy(Factory factory) {
            return new Fabrichniy(factory);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();
            var fabrichniy1 = factory.NewFabrichniy(3);
            var fabrichniy2 = factory.NewFabrichniy(factory);

            Console.WriteLine(fabrichniy1.Field);
            Console.WriteLine(fabrichniy2.Field);
        }
    }
}
