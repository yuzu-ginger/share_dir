using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Compare_Sort_Algo.Benchmark
{
    internal class BenchmarkRunner
    {
        /// <summary>
        /// 1つのアルゴリズム・1つの入力データに対してベンチマークを実行する
        /// </summary>
        /// <param name="sortName">ソートの名前</param>
        /// <param name="original">元の配列</param>
        /// <param name="patternName">配列のパターンの名前</param>
        /// <param name="sortFunc">ソートを実行する関数</param>
        /// <returns>BenchmarkResult クラスのインスタンス</returns>
        public BenchmarkResult RunTest(string sortName, int[] original, string patternName, Action<int[]> sortFunc)
        {
            // 遅いのでスキップ
            ///*
            if (original.Length > 10000 && sortName == "Insertion")
            {
                return BenchmarkResult.Skip(sortName, original.Length, patternName);
            }
            //*/

            // 配列サイズに応じて同じ条件でソートを実行する回数を変える
            int repeat = GetRepeatCount(original.Length);

            long totalTicks = 0;        // 合計実行時間

            // 配列を Clone して ソート関数を実行
            // 1回目だけコンパイル時間 + 実行時間になるため計測しない
            sortFunc((int[])original.Clone());

            // repeat 回ソートを実行する
            for (int i = 0; i < repeat; i++)
            {
                int[] array = (int[])original.Clone();  // 配列を Clone

                Stopwatch sw = Stopwatch.StartNew();  // ストップウォッチ
                sortFunc(array);   // ソート
                sw.Stop();  // 計測をストップ


                totalTicks += sw.ElapsedTicks;           // 実行時間を合計する
            }

            // 結果を返す
            return new BenchmarkResult(
                sortName,
                original.Length,
                patternName,
                totalTicks / repeat      // 実行時間の平均
            );
        }

        /// <summary>
        /// 配列サイズに応じて繰り返し回数を決める
        /// </summary>
        private int GetRepeatCount(int n)
        {
            if (n <= 100) return 200;
            if (n <= 1000) return 100;
            if (n <= 10000) return 50;
            if (n <= 100000) return 10;
            if (n <= 1000000) return 3;
            return 1;
        }
    }
}
