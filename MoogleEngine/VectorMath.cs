using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoogleEngine
{
    public static class VectorMath
    {
        public static double GetCosineSimilarity(Vector<double> lhs, Vector<double> rhs)
        {
            double dot = DotProduct(lhs, rhs);
            if (dot == 0) return 0;

            double lNorm = Norm(lhs);
            if (lNorm == 0) return 0;

            double rNorm = Norm(rhs);
            if (rNorm == 0) return 0;

            return dot / (lNorm * rNorm);
        }
        public static double DotProduct(Vector<double> lhs, Vector<double> rhs)
        {
            return lhs.Length != rhs.Length
                ? throw new ArgumentException($"{nameof(lhs)} and {nameof(rhs)} vectors length mismatch.")
                : lhs.Zip(rhs).Select(tuple => tuple.First * tuple.Second).Sum();
        }
        public static double Norm(Vector<double> vector)
        {
            // The norm of a vector is the square root of the sum of the square of its elements
            return Math.Sqrt(vector._items.Sum(el => el * el));
        }
    }
}