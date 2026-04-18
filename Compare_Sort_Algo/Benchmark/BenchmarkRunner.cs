using System.Diagnostics;

namespace Compare_Sort_Algo.Benchmark
{
    internal class BenchmarkRunner
    {
        /// <summary>
        /// 1つのアルゴリズム・1つの入力データに対してベンチマークを実行する
        /// </summary>
        /// <param name="sortName">ソートの名前</param>
        /// <param name="original">元の配列</param>
        /// <param name="sortFunc">ソートを実行する関数</param>
        /// <returns>BenchmarkResult クラスのインスタンス</returns>
        public BenchmarkResult RunTest(string sortName, int[] original, Action<int[], Counter> sortFunc)
        {
            // 遅いのでスキップ
            if (original.Length > 10000 && sortName == "Insertion")
            {
                return BenchmarkResult.Skip(sortName, original.Length);
            }

            // 配列サイズに応じて同じ条件でソートを実行する回数を変える
            int repeat = GetRepeatCount(original.Length);

            long totalTicks = 0;        // 合計実行時間
            long totalComparisons = 0;  // 合計比較回数
            int maxDepth = 0;           // 再帰の最大の深さ

            // 配列を Clone して ソート関数を実行
            // 1回目だけコンパイル時間 + 実行時間になるため計測しない
            sortFunc((int[])original.Clone(), new Counter());

            // repeat 回ソートを実行する
            for (int i = 0; i < repeat; i++)
            {
                int[] array = (int[])original.Clone();  // 配列を Clone

                Counter counter = new Counter();  // カウンタを生成
                counter.Reset();                  // カウンタをリセット

                Stopwatch sw = Stopwatch.StartNew();  // ストップウォッチ

                sortFunc(array, counter);   // ソート

                sw.Stop();  // 計測をストップ


                totalTicks += sw.ElapsedTicks;           // 実行時間を合計する
                totalComparisons += counter.Comparisons; // 比較回数を合計する

                // 最大再帰回数
                if (counter.MaxDepth > maxDepth)
                {
                    maxDepth = counter.MaxDepth;
                }
            }

            // 結果を返す
            return new BenchmarkResult(
                sortName,
                original.Length,
                totalTicks / repeat,       // 実行時間の平均
                totalComparisons / repeat, // 比較回数の平均
                maxDepth
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
