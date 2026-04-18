using Compare_Sort_Algo.Algorithms;
using Compare_Sort_Algo.Benchmark;
using Compare_Sort_Algo.Data;

namespace Compare_Sort_Algo
{
    internal class Program
    {
        static StreamWriter sw;
        static void Main(string[] args)
        {
            sw = new StreamWriter("C:/Users/nina/Documents/result.csv");
            
            // 配列の要素数
            int[] sizes = { 10, 100, 1000, 10000, 100000, 1000000 };

            // サイズ毎にそれぞれのソートを比較する
            foreach (int n in sizes)
            {
                Console.WriteLine($"\n==============================");
                Console.WriteLine($"N = {n}"); // 要素数を表示
                Console.WriteLine($"==============================");

                var runner = new BenchmarkRunner();

                sw.WriteLine();
                sw.WriteLine($"N={n},Random");
                sw.WriteLine("SortName,AvgTicks,AvgComparisons,MaxDepth");
                RunPattern("Random", DataGenerator.Random(n), runner);

                sw.WriteLine();
                sw.WriteLine($"N={n},Sorted");
                sw.WriteLine("SortName,AvgTicks,AvgComparisons,MaxDepth");
                RunPattern("Sorted", DataGenerator.Sorted(n), runner);

                sw.WriteLine();
                sw.WriteLine($"N={n},Reverse");
                sw.WriteLine("SortName,AvgTicks,AvgComparisons,MaxDepth");
                RunPattern("Reverse", DataGenerator.Reverse(n), runner);

                sw.WriteLine();
                sw.WriteLine($"N={n},Duplicates");
                sw.WriteLine("SortName,AvgTicks,AvgComparisons,MaxDepth");
                RunPattern("Duplicates", DataGenerator.Duplicates(n), runner);

                sw.WriteLine();

            }
            sw.Close();
        }

        /// <summary>
        /// 結果を表示するメソッド
        /// </summary>
        /// <param name="result">BenchmarkResultのインスタンス</param>
        /*
        static void PrintResult(BenchmarkResult result)
        {
            Console.WriteLine(
                $"{result.SortName,-16} " +
                $"Time: {result.AvgTicks,8} ticks  " +
                $"Comp: {result.AvgComparisons,10}  " +
                $"Depth: {result.MaxDepth}"
            );
        }
        */

        static void PrintResult(BenchmarkResult result)
        {
            sw.WriteLine(
                $"{result.SortName},{result.AvgTicks},{result.AvgComparisons},{result.MaxDepth}"
            );
        }

        /// <summary>
        /// 配列のパターンごとにそれぞれのソートを実行するメソッド
        /// </summary>
        /// <param name="patternName">配列のパターンの名前</param>
        /// <param name="data">配列</param>
        /// <param name="runner">ベンチマークのインスタンス</param>
        static void RunPattern(string patternName, int[] data, BenchmarkRunner runner)
        {
            Console.WriteLine($"\n--- {patternName} ---");
            
            // クイックソート
            var quick = new QuickSort();
            var quickResult = runner.RunTest("Quick", data, quick.Sort);
            PrintResult(quickResult);

            // ヒープソート
            var heap = new HeapSort();
            var heapResult = runner.RunTest("Heap", data, heap.Sort);
            PrintResult(heapResult);
            
            // 挿入ソート
            var insertion = new InsertionSort();
            var insertionResult = runner.RunTest("Insertion", data, insertion.Sort);
            PrintResult(insertionResult);

            // クイック + 挿入ソート
            var quickInsertion = new QuickInsertionSort();
            var quickInsertionResult = runner.RunTest("Quick + Insert", data, quickInsertion.Sort);
            PrintResult(quickInsertionResult);

            // クイック + ヒープ
            var quickHeap = new QuickHeapSort();
            var quickHeapResult = runner.RunTest("Quick + Heap", data, quickHeap.Sort);
            PrintResult(quickHeapResult);

            // イントロソート（自作）
            var intro = new IntroSort();
            var introResult = runner.RunTest("IntroSort", data, intro.Sort);
            PrintResult(introResult);

            // Array.Sort (.NET)
            var dotNetArraySort = new DotNetArraySort();
            var dotNetArraySortResult = runner.RunTest("Array.Sort", data, dotNetArraySort.Sort);
            PrintResult(dotNetArraySortResult);
        }
    }
}
