using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW01_AnimalsDLL
{
    public abstract class Animal
    {
        public abstract void Move();
        public abstract void Eat();
    }

    public class Duck : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Утра питается");
        }

        public override void Move()
        {
            Console.WriteLine("Утка переваливаясь гуляет");
        }
    }
    public class Cat : Animal
    {
        private string hunger = "";
        public override void Eat()
        {
            Console.WriteLine("Кот ест");
        }

        public override void Move()
        {
            Console.WriteLine("Кот носится туда сюда");
        }
        private void Digest()
        {
            Console.WriteLine("Кот сыт");
            hunger = "сыт";
        }
    }
}
