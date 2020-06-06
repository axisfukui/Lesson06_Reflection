using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HT01_InterfacesDLL;

namespace HT01_AnimalsLib
{
    public abstract class Animal : IAnimals
    {
        public abstract void Eat();

        public abstract void Move();
    }

    public class Cat : Animal, IDigesting
    {
        public void Digest()
        {
            Console.WriteLine("Кот наелся");
        }

        public override void Eat()
        {
            Console.WriteLine("Кот ест");
        }

        public override void Move()
        {
            Console.WriteLine("Кот гуляет");
        }
    }

    public class Duck : Animal, IDigesting
    {
        public void Digest()
        {
            Console.WriteLine("Утка наелась");
        }

        public override void Eat()
        {
            Console.WriteLine("Утка ест");
        }

        public override void Move()
        {
            Console.WriteLine("Утка гуляет");
        }
    }
}
