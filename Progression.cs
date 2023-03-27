using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirobLab02
{
    public abstract class Progression : IComparable, ICloneable
    {
        public double FirstMember { get; set; }
        public double IncrementOrMultiplier { get; set; }
        public int N { get; set; }

        public Progression(double fm, double inc, int n)
        {
            if(inc == 0)
            {
                throw new ArgumentException("Increment\\Multiplier can't be equal to 0");
            }
            this.FirstMember = fm;
            this.IncrementOrMultiplier = inc;
            this.N = n;
        }

        public override string ToString()
        {
            return $"FirstMember: {FirstMember},\nIncrement or Multiplier: {IncrementOrMultiplier}";
        }

        public abstract double SumOfAll();
        public abstract double SumOfN(int n);
        public abstract double NElem(int n);

        public int CompareTo(object other)
        {
            Progression temp = other as Progression;

            if (this.SumOfAll() > temp.SumOfAll())
            {
                return 1;
            }
            else if (this.SumOfAll() < temp.SumOfAll())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public abstract Progression Add(Progression other);
        public static Progression operator +(Progression a, Progression b)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b));

            return a.Add(b);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
