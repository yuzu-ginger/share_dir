using Compare_Sort_Algo.Benchmark;
namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// ヒープソート
    /// </summary>
    internal class HeapSort : SortBase
    {
        /// <summary>
        /// ヒープソート本体
        /// 配列全体をヒープ構造にしてから、最大値を順に末尾へ送る
        /// </summary>
        public override void Sort(int[] array)
        {
            HeapSortRange(array, 0, array.Length - 1);
        }
    }
}
