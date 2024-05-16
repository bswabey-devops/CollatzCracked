using System.Threading.Tasks;

namespace collatzcracked;

class Program
{
    static void Main(string[] args)
    {
        long iterations = 1000000000;
    
        int numCores = Environment.ProcessorCount;

        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Outer loop to loop through the iterations
        Parallel.For(1, iterations + 1, new ParallelOptions { MaxDegreeOfParallelism = numCores }, (i) =>
        {
            long startingNumber = i;
            long currentNumber = i;
            long stepsCounter = 0;

            // Inner loop to complete the collatz conjecture
            while (currentNumber != 1)
            {
                stepsCounter++;

                if (currentNumber % 2 == 0)
                    currentNumber = currentNumber / 2;
                else
                    currentNumber = currentNumber * 3 + 1;
            }
        });

        watch.Stop();

        Console.WriteLine($"All numbers up to {iterations} resolve down to 1!");
        Console.WriteLine($"Time taken: {watch.ElapsedMilliseconds}");
    }
}