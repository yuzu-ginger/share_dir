using Compare_Sort_Algo.Benchmark;
namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// クイックソート + ヒープソート
    /// </summary>
    internal class QuickHeapSort : SortBase
    {
        /// <summary>
        /// クイックソート + ヒープソートのメソッド
        /// </summary>
        /// <param name="array">n個の要素を持つ配列</param>
        /// <param name="counter">比較回数・再帰をカウント</param>
        public override void Sort(int[] array, Counter counter)
        {
            int depthLimit = 2 * (int)Math.Log2(array.Length);  // 再帰の上限
            QuickHeapRange(array, 0, array.Length - 1, depthLimit, counter);
        }

        /// <summary>
        /// クイック + ヒープソート
        /// 再帰の上限を超えたらヒープソート
        /// </summary>
        /// <param name="array">配列</param>
        /// <param name="left">左端</param>
        /// <param name="right">右端</param>
        /// <param name="depthLimit">再帰の上限</param>
        /// <param name="counter">比較回数、再帰をカウント</param>
        private void QuickHeapRange(int[] array, int left, int right, int depthLimit, Counter counter)
        {
            if (left >= right) return;

            counter.Enter();

            if (depthLimit == 0)  // 再帰のリミットを超えたらヒープソート
            {
                HeapSortRange(array, left, right, counter);
                counter.Exit();
                return;
            }

            // ピボットを設定
            int pivot = array[(left + right) / 2];
            int i = left, j = right;

            // 左と右を比較する
            while (i <= j)
            {
                while (Less(array[i], pivot, counter)) i++;     // 左側
                while (Greater(array[j], pivot, counter)) j--;  // 右側

                // i と j がまだ交差していなければ交換する
                if (i <= j)
                {
                    Swap(array, i, j);
                    i++; j--;
                }
            }

            // pivot を基準に分割された左右の部分配列をそれぞれ再帰的にソート
            QuickHeapRange(array, left, j, depthLimit - 1,  counter);   // pivot 以下の領域
            QuickHeapRange(array, i, right, depthLimit - 1, counter);  // pivot 以上の領域

            // 再帰から帰ってきたのでカウンタ Depth を戻す
            counter.Exit();
        }
    }
}
