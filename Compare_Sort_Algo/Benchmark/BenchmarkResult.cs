namespace Compare_Sort_Algo.Benchmark
{
    internal class BenchmarkResult
    {
        private string _sortName;      // ソートの名前
        private int _n;                // 配列の要素数
        private long _avgTicks;        // 時間
        private long _avgComparisons;  // 比較回数
        private int _maxDepth;         // 再帰の深さ(max)

        public string SortName
        {
            get { return _sortName; }
        }

        public int N
        {
            get { return _n; }
        }

        public long AvgTicks
        {
            get { return _avgTicks; }
        }

        public long AvgComparisons
        {
            get { return _avgComparisons; }
        }

        public int MaxDepth
        {
            get { return _maxDepth; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sortName">ソートの名前</param>
        /// <param name="n">配列の要素数</param>
        /// <param name="avgTicks">時間</param>
        /// <param name="avgComparisons">比較回数</param>
        /// <param name="maxDepth">再帰の深さ(max)</param>
        public BenchmarkResult(string sortName, int n, long avgTicks, long avgComparisons, int maxDepth)
        {
            _sortName = sortName;
            _n = n;
            _avgTicks = avgTicks;
            _avgComparisons = avgComparisons;
            _maxDepth = maxDepth;
        }

        // スキップ
        public static BenchmarkResult Skip(string sortName, int n)
        {
            return new BenchmarkResult(sortName, n, -1, -1, -1);
        }
    }
}
