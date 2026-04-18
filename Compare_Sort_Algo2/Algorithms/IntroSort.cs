using Compare_Sort_Algo.Benchmark;
namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// イントロソート（自作）
    /// </summary>
    internal class IntroSort : SortBase
    {
        /// <summary>
        /// イントロソートのメソッド
        /// </summary>
        /// <param name="array">n個の要素を持つ配列</param>
        public override void Sort(int[] array)
        {
            int depthLimit = 2 * (int)Math.Log2(array.Length);  // 再帰の上限
            IntroSortRange(array, 0, array.Length - 1, depthLimit);
        }

        /// <summary>
        /// イントロソート（自作）
        /// 要素数が16以下ならその区間だけ挿入ソートに切り替える
        /// 再帰の上限を超えたらヒープソート
        /// </summary>
        /// <param name="array">配列</param>
        /// <param name="left">左端</param>
        /// <param name="right">右端</param>
        /// <param name="depthLimit">再帰の上限</param>
        private void IntroSortRange(int[] array, int left, int right, int depthLimit)
        {
            if (left >= right) return;

            // 小さい区間は挿入ソート
            if (right - left + 1 <= 16)
            {
                InsertionRange(array, left, right);
                return;
            }

            if (depthLimit == 0)  // 再帰のリミットを超えたらヒープソート
            {
                HeapSortRange(array, left, right);
                return;
            }

            // ピボットを設定
            int pivot = array[(left + right) / 2];
            int i = left, j = right;

            // 左と右を比較する
            while (i <= j)
            {
                while (array[i] < pivot) i++;  // 左側
                while (array[j] > pivot) j--;  // 右側

                // i と j がまだ交差していなければ交換する
                if (i <= j)
                {
                    //Swap(array, i, j);
                    if (i != j)
                    {
                        // スワップ
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                    i++; j--;
                }
            }

            // pivot を基準に分割された左右の部分配列をそれぞれ再帰的にソート
            IntroSortRange(array, left, j, depthLimit - 1);   // pivot 以下の領域
            IntroSortRange(array, i, right, depthLimit - 1);  // pivot 以上の領域
        }
    }
}
