using Compare_Sort_Algo.Benchmark;
namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// 挿入ソート
    /// </summary>
    internal class InsertionSort : SortBase
    {
        /// <summary>
        /// 挿入ソートのメソッド
        /// </summary>
        /// <param name="array">n個の要素を持つ配列</param>
        /// <param name="counter">比較回数・再帰をカウント</param>
        public override void Sort(int[] array, Counter counter)
        {
            InsertionRange(array, 0, array.Length - 1, counter);
        }
    }
}
