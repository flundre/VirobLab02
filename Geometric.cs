using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirobLab02
{
    class Geometric : Progression
    {
        public event EventHandler MultiplierLessThanOne;

        private double Multiplier;

        public new double IncrementOrMultiplier { get { if (Math.Abs(Multiplier) < 1) { OnSumOfInfinity(EventArgs.Empty); } return Multiplier; } set { this.Multiplier = value;if (Math.Abs(value) < 1) { OnSumOfInfinity(EventArgs.Empty); } } }

        public Geometric(double fm, double inc, int n) : base(fm, inc, n) {
            if(Math.Abs(inc) == 1)
            {
                throw new ArgumentException("Abs of multiplier can't be equal to 1");
            }
            MultiplierLessThanOne += MultiplierIsLessThanOne;

        }

        protected virtual void MultiplierIsLessThanOne(object sender, EventArgs e)
        {
            Console.WriteLine("Multiplier is less than one!You can get infinite sum");
        }

        public void OnSumOfInfinity(EventArgs e)
        {
            MultiplierLessThanOne?.Invoke(this, e);
        }

        public double SumOfInfinity()
        {
            if (Math.Abs(IncrementOrMultiplier) < 1)
            {
                return FirstMember / (1 - IncrementOrMultiplier);
            }
            throw new ArgumentException("Abs of Multiplier must be less than 1 for SumOfInfinity");
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
