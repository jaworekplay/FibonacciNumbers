using System.Collections.Generic;
using System.Linq;

namespace FibonacciNumbers.Services
{
    public interface IFibonacciService
    {
        List<int> FibonacciSequence { get; }

        IEnumerable<int> GetEvenNumbers();
    }

    public class FibonacciService : IFibonacciService
    {
        private const int FibonacciUpperLimit = 4_000_000;

        public FibonacciService()
        {
            FibonacciSequence = new List<int>();

            int a = 1, b = 2, c = 0;
            for (int i = 0; c < FibonacciUpperLimit; i++)
            {
                c = a + b;
                FibonacciSequence.Add(c);
                a = b;
                b = c;
            }
        }

        public IEnumerable<int> GetEvenNumbers()
        {
            return FibonacciSequence.Where(i => i % 2 == 0);
        }

        public List<int> FibonacciSequence { get; private set; }
    }
}
