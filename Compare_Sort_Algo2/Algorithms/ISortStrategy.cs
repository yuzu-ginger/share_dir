using Compare_Sort_Algo.Benchmark;
namespace Compare_Sort_Algo.Algorithms
{
    /// <summary>
    /// ソートアルゴリズムのインターフェース
    /// </summary>
    internal interface ISortStrategy
    {
        public void Sort(int[] array);
    }
}
