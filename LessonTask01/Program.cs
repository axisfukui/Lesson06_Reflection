using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using LW01_AnimalsDLL;

namespace LessonTask01
{
    //Создайте DLL библиотеку Animals с классами Animal(абстрактный), Duck и Cat(конкретные классы). В абстрактном классе объявите, а в конкретных – 
    //реализуйте такие публичные методы: Move(), Eat() и приватный метод у класса Cat – Digest() (переваривать) – выводит на экран фразу «кот сыт» и 
    //присваивает значение приватному полю hunger значение «сыт».
    //Создайте запускаемый проект.В данном проекте создайте класс Human.В теле класса создайте метод Feed(ref Object objectToFeed). Подключите библиотеку 
    //Animals, используя ссылки.
    //В методе Main создайте экземпляр человека, экземпляр кота. Покормите кота.

    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Move();
            object catObject = (object)cat;
            Human human = new Human();
            human.Feed(ref catObject);
        }
    }
    class Human
    {
        public void Feed(ref Object objectToFeed)
        {
            Console.WriteLine("Человек кормит");
            Cat cat = objectToFeed as Cat;
            cat.Eat();
            
        }
    }
}
