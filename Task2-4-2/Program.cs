using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<int> ListToCheck = new List<int>();
            Dictionary<int, int> Frequency = new Dictionary<int, int>();

            for (int i = 0; i < 50; i++)
            {
                ListToCheck.Add(rng.Next(0, 10));
            }

            for (int i = 0; i < 10; i++)
            {
                var res = from l in ListToCheck
                          where l == i
                          select l;
                Frequency.Add(i, res.Count());
            }
            foreach (var pair in Frequency)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
            Console.ReadKey();
        }
    }
}
