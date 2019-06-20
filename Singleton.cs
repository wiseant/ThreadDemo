using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadDemo
{
    public class Singleton
    {
        public Guid Id { get; }
        private static Singleton instance;
        //使用线程锁，在创建实例前先加锁，可以保证线程安全
        private static readonly object obj_lock = new object();

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj_lock)
                    {
                        //线程锁定后一定要再次检查instance是否为null。
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }

        private Singleton()
        {
            this.Id = Guid.NewGuid();
            System.Threading.Thread.Sleep(5 * 1000);//等待5秒
            Console.WriteLine($"{this.GetType().Name} created, Id={Id}");
        }
    }

    public class SingletonToo
    {
        public Guid Id { get; }
        //使用饿汉模式，在声明静态属性时创建实例也是线程安全的。
        private static readonly SingletonToo instance = new SingletonToo();

        public static SingletonToo Instance => instance;

        private SingletonToo()
        {
            this.Id = Guid.NewGuid();
            System.Threading.Thread.Sleep(5 * 1000);//等待5秒
            Console.WriteLine($"{this.GetType().Name} created, Id={Id}");
        }
    }

    public class SingletonFaulty
    {
        public Guid Id { get; }
        private static SingletonFaulty instance;
        
        // 这种方式获取单个实例是非线程安全的
        public static SingletonFaulty Instance => instance ?? (instance = new SingletonFaulty());


        private SingletonFaulty()
        {
            this.Id = Guid.NewGuid();
            System.Threading.Thread.Sleep(5 * 1000);//等待5秒
            Console.WriteLine($"{this.GetType().Name} created, Id={Id}");
        }
    }
}
