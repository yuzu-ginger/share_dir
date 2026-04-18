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
        public override void Sort(int[] array)
        {
            InsertionRange(array, 0, array.Length - 1);
        }
    }
}
