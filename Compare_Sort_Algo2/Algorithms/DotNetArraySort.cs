using Compare_Sort_Algo.Benchmark;
namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// .NET Array.Sort
    /// </summary>
    internal class DotNetArraySort : SortBase
    {
        /// <summary>
        /// .NET の Array.Sort を実行するメソッド
        /// </summary>
        /// <param name="array">n個の要素を持つ配列</param>
        public override void Sort(int[] array)
        {
            Array.Sort(array);
        }
    }
}
