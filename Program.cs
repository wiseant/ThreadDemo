using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunMultiThreadTest();
        }

        static void RunMultiThreadTest()
        {
            while (true)
            {
                Console.WriteLine("1.正例一\n2.正例二\n3.反例\n请选择：");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        TestAccurately();
                        return;
                    case "2":
                        TestAccurately();
                        return;
                    case "3":
                        TestFaultily();
                        return;
                    default:
                        Console.WriteLine("请输入正确的序号！");
                        break;
                }
            }
        }

        private static void TestAccurately()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(new ThreadStart(Test)).Start();
            }

            void Test()
            {
                Console.WriteLine($"{Singleton.Instance.Id}");
            }
        }

        private static void TestAccurately2()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(new ThreadStart(Test)).Start();
            }

            void Test()
            {
                Console.WriteLine($"{SingletonToo.Instance.Id}");
            }
        }

        private static void TestFaultily()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(new ThreadStart(Test)).Start();
            }

            void Test()
            {
                Console.WriteLine($"{SingletonFaulty.Instance.Id}");
            }
        }
    }
}
