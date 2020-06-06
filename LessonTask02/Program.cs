using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace LessonTask02
{
    //Создайте DLL библиотеку Animals с классами Animal(абстрактный), Duck и Cat(конкретные классы). В абстрактном классе объявите, а в конкретных – 
    //реализуйте такие публичные методы: Move(), Eat() и приватный метод у класса Cat – Digest() (переваривать) – выводит на экран фразу «кот сыт» и 
    //присваивает значение приватному полю hunger значение «сыт».
    //Создайте запускаемый проект.В данном проекте создайте класс Human.В теле класса создайте метод Feed(ref Object objectToFeed). Подключите библиотеку 
    //Animals, используя ссылки.
    //В методе Main создайте экземпляр человека, экземпляр кота. Покормите кота.

    //Выполните задачу 1, исходя из того, что вы подгружаете библиотеку Animals, используя класс Assembly.Также выведите на экран консоли информацию о всех классах библиотеки Animals, о всех методах и всех полях классов библиотеки Animals.
    class Program
    {
        static void Main(string[] args)
        {
            
            Human human = new Human();
            
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("LW01_AnimalsDLL");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
            GetFullLibInfo(assembly);

            
            Type cat = assembly.GetType("LW01_AnimalsDLL.Cat");            
            object catObject = Activator.CreateInstance(cat);

            var catMove = cat.GetMethod("Move");
            catMove.Invoke(catObject, null);

            human.Feed(ref catObject);

            //Чтение приватного поля из соответствующего класса при его наличие.
            var field = cat.GetField("hunger", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field!=null)
                Console.WriteLine($"Статус Кота: Кот {field.GetValue(catObject)}");
        }

        /// <summary>
        /// Get Full Assembly information
        /// </summary>
        /// <param name="assembly"></param>
        private static void GetFullLibInfo(Assembly assembly)
        {
            //Get Class Information
            Type[] classList = assembly.GetTypes();

            List<Type> cL = new List<Type>();
            foreach (var item in classList)
            {
                Console.WriteLine(item.Name + "\t" + item.FullName);
                cL.Add(item);
            }
            Console.WriteLine(new string('#', 50));

            //Get Full Information
            foreach (var @class in cL)
            {
                Console.WriteLine("Class:\t" + @class.Name + "\t" + @class.FullName);
                foreach (var method in @class.GetMethods(BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance))
                {
                    Console.WriteLine("Method:\t" + method.Name);
                }
                foreach (var field in @class.GetFields(BindingFlags.NonPublic
                    | BindingFlags.Public
                    | BindingFlags.Instance))
                {
                    Console.WriteLine("Field:\t" + field.Name);
                }
                Console.WriteLine(new string('-', 50));
            }
        }
    }
    class Human
    {
        public void Feed(ref Object objectToFeed)
        {
            Type cat = objectToFeed.GetType();
            if (cat.Name == "Cat")
            {
                Console.WriteLine($"Человек кормит Животинку");
                MethodInfo method = cat.GetMethod("Eat");
                method.Invoke(objectToFeed, null);

                //выполнение 3 задания: Вызов private метода из соответствующего класса
                MethodInfo digest = cat.GetMethod("Digest",BindingFlags.Instance|BindingFlags.NonPublic);
                digest.Invoke(objectToFeed, null);

            }
            else
                Console.WriteLine("Человеку некого кормить");


        }
    }
}
