using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirobLab02
{
    public class Arithmetic : Progression
    {
        public Arithmetic(double fm, double inc, int n) : base(fm, inc, n) { }

        public override double SumOfAll() {
            return 0.5 * IncrementOrMultiplier * N * N + (FirstMember - 0.5 * IncrementOrMultiplier) * N;
        }
        public override double SumOfN(int n) {
            return 0.5 * IncrementOrMultiplier * n * n + (FirstMember - 0.5 * IncrementOrMultiplier) * n;
        }
        public override double NElem(int n) {
            return FirstMember + (n - 1) * IncrementOrMultiplier;
        }
        public override string ToString()
        {
            return $"FirstMember: {FirstMember},\nIncrement: {IncrementOrMultiplier}";
        }
        //public static Arithmetic operator +(Arithmetic a, Arithmetic b)
        //{
        //    Arithmetic result = a;
        //    result.FirstMember =+ b.FirstMember;
        //    result.IncrementOrMultiplier =+ b.IncrementOrMultiplier;
        //    result.N =+ b.N;
        //    return result;
        //}

        public override Progression Add(Progression other) {
            return new Arithmetic(this.FirstMember + other.FirstMember, this.IncrementOrMultiplier + other.IncrementOrMultiplier, this.N + other.N);
        }
    }
}
