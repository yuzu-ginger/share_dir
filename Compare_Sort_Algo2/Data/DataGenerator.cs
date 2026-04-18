namespace Compare_Sort_Algo.Data
{
    internal static class DataGenerator
    {
        private static Random _rand = new Random(0);

        /// <summary>
        /// ランダムな配列
        /// </summary>
        /// <param name="n">要素数</param>
        /// <returns>配列</returns>
        public static int[] Random(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = _rand.Next();
            }
            return array;
        }

        /// <summary>
        /// 昇順に並べられた配列
        /// </summary>
        /// <param name="n">要素数</param>
        /// <returns>配列</returns>
        public static int[] Sorted(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i;
            }
            return array;
        }

        /// <summary>
        /// 降順に並べられた配列
        /// </summary>
        /// <param name="n">要素数</param>
        /// <returns>配列</returns>
        public static int[] Reverse(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = n - i;
            }
            return array;
        }

        /// <summary>
        /// 要素が重複する配列
        /// </summary>
        /// <param name="n">要素数</param>
        /// <returns>配列</returns>
        public static int[] Duplicates(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i % 3;
            }
            return array;
        }
    }
}
