using System;

namespace nested
{
    public class Outer1 {
        string Field = "321";
        class Nested1
        {
            string Field = "123";
        }
    }

    public class Outer2
    {
        string Field = "432";
        public class Nested2
        {
            string Field = "234";
            public Nested2() { }
            public Nested2(Outer2 outer2)
            {
                Field = outer2.Field;
            }
        }
    }



    public abstract class Animal
    {
        private Animal() { } 
        private sealed class Dog : Animal { }
        private sealed class Cat : Animal { }
        public static Animal CreateDog() {
            Console.WriteLine("dog");
            return new Dog();
        }
        public static Animal CreateCat() {
            Console.WriteLine("cat");
            return new Cat();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var outer1 = new Outer1();

            var outer2 = new Outer2();

            Outer2.Nested2 nested2 = new Outer2.Nested2();
            //Outer1.Nested1 nested1 = new Outer1.Nested1();

            var cat = Animal.CreateCat();
        }
    }
}
