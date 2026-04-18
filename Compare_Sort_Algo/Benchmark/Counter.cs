namespace Compare_Sort_Algo.Benchmark
{
    /// <summary>
    /// 比較回数・再帰の深さをカウントするクラス
    /// </summary>
    internal class Counter
    {
        private long _comparisons = 0;  // 比較回数
        private int _depth = 0;         // 再帰の深さ
        private int _maxDepth = 0;      // 再帰の深さ(max)


        // プロパティ
        public long Comparisons
        {
            get { return _comparisons; }
        }

        public int MaxDepth
        {
            get { return _maxDepth; }
        }

        /// <summary>
        /// カウンタをリセットするメソッド
        /// </summary>
        public void Reset()
        {
            _comparisons = 0;
            _depth = 0;
            _maxDepth = 0;
        }

        /// <summary>
        /// 比較回数をカウントするメソッド
        /// 呼び出されるごとに Comparisons を加算する
        /// </summary>
        public void Compare()
        {
            _comparisons++;
        }

        /// <summary>
        /// 再帰の深さをカウントするメソッド
        /// 呼び出されるごとに Depth を加算する
        /// 新しい Depth が MaxDepth を超えたら MaxDepth を更新する
        /// </summary>
        public void Enter()
        {
            _depth++;
            if (_depth > _maxDepth)
            {
                _maxDepth = _depth;
            }
        }

        /// <summary>
        /// 再帰から戻ったときのメソッド
        /// 呼び出されるごとに Depth を 1 減らす
        /// </summary>
        public void Exit()
        {
            _depth--;
        }
    }
}
