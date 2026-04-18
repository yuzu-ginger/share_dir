using Compare_Sort_Algo.Benchmark;

namespace Compare_Sort_Algo.Algorithms
{
    internal abstract class SortBase : ISortStrategy
    {
        public abstract void Sort(int[] array, Counter counter);

        /// <summary>
        /// 配列内の指定されたインデックスにある要素を交換するメソッド
        /// </summary>
        /// <param name="array">要素が交換される配列</param>
        /// <param name="i">交換する最初の要素のインデックス</param>
        /// <param name="j">交換する 2 番目の要素のインデックス</param>
        protected void Swap(int[] array, int i, int j)
        {
            // インデックスが等しい場合は実行しない
            if (i == j) return;

            // スワップ
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        /// <summary>
        /// a が b より小さいかどうかを判断して比較回数を加算
        /// </summary>
        /// <param name="a">1つ目の値</param>
        /// <param name="b">2つ目の値</param>
        /// <param name="counter">比較回数をカウント</param>
        /// <returns>bool</returns>
        protected bool Less(int a, int b, Counter counter)
        {
            counter.Compare();
            return a < b;
        }

        /// <summary>
        /// a が b より大きいかどうかを判断して比較回数を加算
        /// </summary>
        /// <param name="a">1つ目の値</param>
        /// <param name="b">2つ目の値</param>
        /// <param name="counter">比較回数をカウント</param>
        /// <returns>bool</returns>
        protected bool Greater(int a, int b, Counter counter)
        {
            counter.Compare();
            return a > b;
        }

        /// <summary>
        /// 挿入ソート
        /// </summary>
        /// <param name="array">配列</param>
        /// <param name="left">左端</param>
        /// <param name="right">右端</param>
        /// <param name="counter">比較回数をカウント</param>
        protected void InsertionRange(int[] array, int left, int right, Counter counter)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (true)
                {
                    if (j < left) break;   // 左端に来たら終了

                    counter.Compare();     // 比較回数 Comparisons++

                    if (array[j] <= key) break;  // 左側の値が key 以下になったら終了

                    array[j + 1] = array[j];   // 要素を1つ右にずらす
                    j--;
                }
                array[j + 1] = key;
            }
        }

        /// <summary>
        /// 指定範囲 [left, right] をヒープソートする
        /// </summary>
        /// <param name="array">配列</param>
        /// <param name="left">左端</param>
        /// <param name="right">右端</param>
        /// <param name="counter">比較回数をカウント</param>
        protected void HeapSortRange(int[] array, int left, int right, Counter counter)
        {
            int n = right - left + 1;

            // 下から順にHeapifyすることで全体をヒープにする
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i, left, counter);
            }

            // ルート（最大値）を末尾に移動し、ヒープサイズを縮める
            for (int i = n - 1; i > 0; i--)
            {
                // 最大値を末尾へ
                Swap(array, left, left + i);

                // ヒープサイズを1つ減らして再ヒープ化
                Heapify(array, i, 0, left, counter);
            }
        }

        /// <summary>
        /// i を根とする部分木をヒープ条件を満たすように調整する
        /// </summary>
        protected void Heapify(int[] array, int n, int i, int offset, Counter counter)
        {
            int largest = i;       // 現在の最大値のインデックス
            int l = 2 * i + 1;     // 左の子
            int r = 2 * i + 2;     // 右の子

            if (l < n && Greater(array[offset + l], array[offset + largest], counter))  // 左の子と比較
                largest = l;

            if (r < n && Greater(array[offset + r], array[offset + largest], counter))  // 右の子と比較
                largest = r;

            // 最大値が親でない場合
            if (largest != i)
            {
                // 親と子を交換
                Swap(array, offset + i, offset + largest);

                // 交換先の部分木もヒープ条件を満たすよう再帰
                Heapify(array, n, largest, offset, counter);
            }
        }
    }
}
