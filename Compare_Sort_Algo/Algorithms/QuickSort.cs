using Compare_Sort_Algo.Benchmark;

namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// クイックソート
    /// </summary>
    internal class QuickSort : SortBase
    {
        /// <summary>
        /// クイックソートのメソッド
        /// </summary>
        /// <param name="array">n個の要素を持つ配列</param>
        /// <param name="counter">比較回数・再帰をカウント</param>
        public override void Sort(int[] array, Counter counter)
        {
            QuickSortInternal(array, 0, array.Length - 1, counter);
        }

        /// <summary>
        /// クイックソート
        /// pivot を中心に部分配列を再帰的に並べ替える
        /// </summary>
        /// <param name="array">配列</param>
        /// <param name="left">開始インデックス</param>
        /// <param name="right">終了インデックス</param>
        /// <param name="counter">再帰の数をカウント</param>
        private void QuickSortInternal(int[] array, int left, int right, Counter counter)
        {
            // left の方が right 以上なら返す
            if (left >= right) return;

            counter.Enter();

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
            QuickSortInternal(array, left, j, counter);   // pivot 以下の領域
            QuickSortInternal(array, i, right, counter);  // pivot 以上の領域

            // 再帰から帰ってきたのでカウンタ Depth を戻す
            counter.Exit();
        }
    }
}
