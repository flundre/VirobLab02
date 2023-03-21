using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirobLab02
{
    class Geometric : Progression
    {
        public Geometric(double fm, double inc, int n) : base(fm, inc, n) {
            if(Math.Abs(inc) == 1)
            {
                throw new ArgumentException("Abs of multiplier can't be equal to 1");
            }
        }

        public double SumOfInfinity()
        {
            if (Math.Abs(IncrementOrMultiplier) < 1)
            {
                throw new ArgumentException("Abs of Multiplier must be less than 1 for SumOfInfinity");
            }
            return FirstMember/(1-IncrementOrMultiplier);
        }
        public override string ToString()
        {
            return $"FirstMember: {FirstMember},\nMultiplier: {IncrementOrMultiplier}";
        }
        public override double SumOfAll()
        {
            return (FirstMember*(Math.Pow(IncrementOrMultiplier, N)-1))/(IncrementOrMultiplier-1);
        }
        public override double SumOfN(int n)
        {
            return (FirstMember * (Math.Pow(IncrementOrMultiplier, n) - 1)) / (IncrementOrMultiplier - 1);
        }
        public override double NElem(int n)
        {
            return FirstMember * Math.Pow(IncrementOrMultiplier, n-1);
        }
        public override Progression Add(Progression other)
        {
            return new Geometric(this.FirstMember + other.FirstMember, this.IncrementOrMultiplier + other.IncrementOrMultiplier, this.N + other.N);
        }

    }
}
