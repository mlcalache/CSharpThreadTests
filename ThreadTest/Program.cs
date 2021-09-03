using System;
using System.Threading.Tasks;

namespace ThreadTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($">> Iteration: {i}");

                var t1 = Task.Run(async () =>
                {
                    var x = await DoSomethingAsync1();
                    Console.WriteLine($"result : {x}");
                    return x;
                });

                var t2 = Task.Run(async () =>
                {
                    var x = await DoSomethingAsync2();
                    Console.WriteLine($"result : {x}");
                    return x;
                });

                var t3 = Task.Run(async () =>
                {
                    var x = await DoSomethingAsync3();
                    Console.WriteLine($"result : {x}");
                    return x;
                });

                Task.WaitAll(t1, t2, t3);
            }

            //if (t1.IsCompletedSuccessfully)
            //{
            //    var x = t1.GetAwaiter().GetResult();
            //    Console.WriteLine($"result : {x}");
            //}
            //if (t2.IsCompletedSuccessfully)
            //{
            //    var x = t2.GetAwaiter().GetResult();
            //    Console.WriteLine($"result : {x}");
            //}
            //if (t3.IsCompletedSuccessfully)
            //{
            //    var x = t3.GetAwaiter().GetResult();
            //    Console.WriteLine($"result : {x}");
            //}

            Console.ReadKey();
        }

        public static async Task<int> DoSomethingAsync1()
        {
            var task = Task.Run(async () =>
            {
                await Task.Delay(1_000);
                return 1;
            });

            var dt1 = DateTime.Now;
            var r = task.Result;
            var dtDiff = DateTime.Now - dt1;

            return r;
        }

        public static async Task<int> DoSomethingAsync2()
        {
            var task = Task.Run(async () =>
            {
                await Task.Delay(1_000);
                return 2;
            });

            var dt1 = DateTime.Now;
            var r = task.GetAwaiter().GetResult();
            var dtDiff = DateTime.Now - dt1;

            return r;
        }

        public static async Task<int> DoSomethingAsync3()
        {
            var task = Task.Run(async () =>
            {
                await Task.Delay(1_000);
                return 3;
            });

            var dt1 = DateTime.Now;
            var r = await task;
            var dtDiff = DateTime.Now - dt1;

            return r;
        }
    }
}