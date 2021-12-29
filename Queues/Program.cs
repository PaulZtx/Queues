using System;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            Sort queue = new Sort();

            int step = 300;

            for(int i = 0; i < 10; ++i)
            {
                queue.Clear();
                var rnd = new Random();

                var myStopwatch = new System.Diagnostics.Stopwatch();
                

                for (int j = 0; j < step; ++j)
                    queue.Enqueue(rnd.Next(-1000, 1000));
                

                myStopwatch.Start();

                queue.QuickSort(0, queue.Count - 1);

                myStopwatch.Stop();
                Console.WriteLine($"Номер сортировки: {i + 1}, количество элементов: {step}, время выполнения: {myStopwatch.Elapsed}, количество операций: {queue.Counter}");
                step += 300;
            }
            
     

        }

    }
}
