using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1
{
    abstract class BaseWorker : IComparable
    {
        public abstract string Name { get; set; }
        public abstract double MonthlySalary { get; set; }

        public abstract void GetMonthlySalary(double _salary);
        public int CompareTo(object obj)
        {
            var other = obj as BaseWorker;
            return this.MonthlySalary < other.MonthlySalary ? -1 : 1;
        }
    }
    class HourWorker : BaseWorker
    {
        public override double MonthlySalary { get; set; }
        public override string Name { get; set; }

        public override void GetMonthlySalary(double salary)
        {
            this.MonthlySalary = salary * 20.8 * 8;
        }
        public HourWorker(string name, double hourSalary)
        {
            this.Name = name;
            GetMonthlySalary(hourSalary);
        }

    }
    class FixedWorker : BaseWorker
    {
        public override double MonthlySalary { get; set; }
        public override string Name { get; set; }

        public override void GetMonthlySalary(double salary)
        {
            this.MonthlySalary = salary;
        }
        public FixedWorker(string name, double monthSalary)
        {
            this.Name = name;
            GetMonthlySalary(monthSalary);
        }
    }
    class WorkSpace : IEnumerable
    {
        public List<BaseWorker> workers;

        public WorkSpace()
        {
            workers = new List<BaseWorker> { new FixedWorker("CultLeader", 0) };
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < workers.Count; i++)
            {
                yield return workers[i];
            }
        }
    }
}
