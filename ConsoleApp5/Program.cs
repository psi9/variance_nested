using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    public interface ICovariant<out T>
    {
        T Property1 { get; }
        T Property2 { get; }
        //T Property2 { get; set; }
        public T this[int i] { get; }
        //public T this[int i] { get; set; }
    }
    public class Covariant<T> : ICovariant<T>
    {
        public T Property1 { get; set; }

        public T Property2 { get; set; }

        public T this[int i]
        {
            get
            {
                if (i == 1)
                {
                    return Property1;
                }
                return Property2;
            }
            set
            {
                Property1 = value;
            }
        }
    }


    public interface IContravariant<in T>
    {
        T Property { set; }
    }

    public class Contravariant<T> : IContravariant<T>
    {
        public T Property { get; set; }
    }


    class Parent
    {
        public int Field { get; set; }
        public void Write()
        {
            Console.WriteLine("parent");
        }
    }

    class Child : Parent
    {
    }

    class Program
    {
        static void ConsoleParent(Parent parent)
        {
            parent.Field = 1;
            Console.WriteLine("parent");
        }
        static void ConsoleChild(Child child)
        {
            child.Field = 2;
            Console.WriteLine("child");
        }

        static void Main(string[] args)
        {
            List <Parent> list1 = new List<Parent>();
            //List<Parent> fail = new List<Child>();

            ICovariant<Parent> covariant = new Covariant<Child>();
            IEnumerable<Parent> list = new List<Child>();

            static Child Primer(string xxx)
            {
                return new Child();
            }
            Func<string, Child> primerChild = Primer;
            Func<string, Parent> primerParent = Primer;
            primerParent = primerChild;






            IContravariant<Child> contravariant = new Contravariant<Parent>();

            Action<Child> exampleDelegate;
            var child = new Child();

            exampleDelegate = ConsoleParent;
            exampleDelegate(child);

            Console.WriteLine(child.Field);


            static void Primer2(Parent parent)
            {
                
            }
            Action<Parent> primerChild2 = Primer2;
            Action<Child> primerParent2 = Primer2;
            primerParent2 = primerChild2;


            Console.WriteLine("111");
            
        }
    }
}
