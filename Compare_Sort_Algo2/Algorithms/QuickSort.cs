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
        public override void Sort(int[] array)
        {
            QuickSortInternal(array, 0, array.Length - 1);
        }

        /// <summary>
        /// クイックソート
        /// pivot を中心に部分配列を再帰的に並べ替える
        /// </summary>
        /// <param name="array">配列</param>
        /// <param name="left">開始インデックス</param>
        /// <param name="right">終了インデックス</param>
        private void QuickSortInternal(int[] array, int left, int right)
        {
            // left の方が right 以上なら返す
            if (left >= right) return;

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
            QuickSortInternal(array, left, j);   // pivot 以下の領域
            QuickSortInternal(array, i, right);  // pivot 以上の領域
        }
    }
}
