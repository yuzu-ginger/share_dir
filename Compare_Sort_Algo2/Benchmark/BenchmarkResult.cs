namespace Compare_Sort_Algo.Benchmark
{
    internal class BenchmarkResult
    {
        private string _sortName;      // ソートの名前
        private int _n;                // 配列の要素数
        private string _patternName;   // 配列のパターン
        private long _avgTicks;        // 時間

        public string SortName
        {
            get { return _sortName; }
        }

        public int N
        {
            get { return _n; }
        }

        public string PatternName
        {
            get { return _patternName;  }
        }

        public long AvgTicks
        {
            get { return _avgTicks; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sortName">ソートの名前</param>
        /// <param name="n">配列の要素数</param>
        /// <param name="avgTicks">時間</param>
        public BenchmarkResult(string sortName, int n, string patternName, long avgTicks)
        {
            _sortName = sortName;
            _n = n;
            _patternName = patternName;
            _avgTicks = avgTicks;
        }

        // スキップ
        public static BenchmarkResult Skip(string sortName, int n, string patternName)
        {
            return new BenchmarkResult(sortName, n, patternName, -1);
        }
    }
}
