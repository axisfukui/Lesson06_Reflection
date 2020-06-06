using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HT01_InterfacesDLL;
using System.Collections;

namespace HomeTask01
{
    //Измените проект библиотеки из классной задачи 1 следующим образом:
    //Класс Animal должен реализовывать интерфейс IAnimal с методами Move(), Eat(). Классы Duck и Cat должны реализовывать интерфейс Idigesting с 
    //методом Digest(). Выполните подгрузку библиотеки в другом проекте, содержащем класс Human, аналогично классной задаче 1.
    //Программа должна работать следующим образом.Пользователь вводит строку в консоль.Если эта строка содержит слово «утка» («утку») в любом 
    //регистре – человек должен покормить экземпляр утки, если содержит слово «кот» («кошка», «кошку», «кошку» в любом регистре) - покормить 
    //экземпляр кота.Если содержит и утку, и кота – покормить обоих.Экземпляры класса для «кормления» получайте, используя рефлексию.

    enum AnimalFlags
    {
        none = 0,
        Cat = 1,
        Duck = 2,
        Animal = 16
    }
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;
            Type[] animals = null;
            try
			{
                assembly = Assembly.Load("HT01_AnimalsLib");
                animals = assembly.GetTypes();
			}
			catch (FileNotFounException e)
			{
                Console.WriteLine(e.Message);
			}

            Console.WriteLine("Введите живность для кормления");
            string str = Console.ReadLine().ToLower();

            AnimalFlags flag = AnimalFlags.none;
            if (str.Contains("утк")==true)
                flag = AnimalFlags.Duck;
            if (str.Contains("кошк") == true || str.Contains("кот") == true)
                flag = flag | AnimalFlags.Cat;

            Human human = new Human();
            if (animals!=null)
                human.Food(animals, flag);
        }
    }
    class Human
    {
        public void Food (Type[] animals, AnimalFlags animalFlags)
        {
            Console.WriteLine("Человек кормит живность...");
            AnimalFlags tempFlag = AnimalFlags.none;
            IEnumerator type = animals.GetEnumerator();
            while (type.MoveNext())
            {
                if ((type.Current as Type).Name == "Cat")
                    tempFlag = animalFlags & AnimalFlags.Cat;
                if ((type.Current as Type).Name == "Duck")
                    tempFlag = animalFlags & AnimalFlags.Duck;
                switch (tempFlag)
                {
                    case AnimalFlags.Cat:
                        IAnimals cat = Activator.CreateInstance((type.Current as Type)) as IAnimals;
                        cat.Eat();
                        break;
                    case AnimalFlags.Duck:
                        IAnimals duck = Activator.CreateInstance((type.Current as Type)) as IAnimals;
                        duck.Eat();
                        break;
                }
            }
        }
    }
}
