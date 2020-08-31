using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            WorkSpace temple = new WorkSpace();
            BaseWorker[] _workers = new BaseWorker[20];
            Console.WriteLine("Рабочие (до сортировки):");
            for (int i = 0; i < _workers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    _workers[i] = new FixedWorker(Guid.NewGuid().ToString(), (double)rng.Next(i, 20000));
                } else
                {
                    _workers[i] = new HourWorker(Guid.NewGuid().ToString(), (double)rng.Next(i, 150));
                }
                Console.WriteLine($"Рабочий {i,2}, Имя: {_workers[i].Name,10}, ЗП/Месяц: {_workers[i].MonthlySalary}");
            }
            Array.Sort(_workers);
            Console.WriteLine("После сортировки");
            for (int i = 0; i < _workers.Length; i++)
            {
                Console.WriteLine($"Рабочий {i,2}, Имя: {_workers[i].Name,10}, ЗП/Месяц: {_workers[i].MonthlySalary}");
                
            }
            temple.workers.AddRange(_workers);

            Console.WriteLine("Рабочих перевели на другое место работы:");
            foreach (BaseWorker cultist in temple)
            {
                Console.WriteLine($"{cultist.Name}, {cultist.MonthlySalary}");
            }

            Console.ReadKey();
        }
    }
}
