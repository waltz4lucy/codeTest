using System;
using NUnit.Framework;

namespace CodeTest
{
    public class TreeNode
    {
        public TreeNode()
        {
            //Q1. 반복문을 사용하지 않고 정수 n1 ~ n2 합을 구하라.
            Assert.AreEqual(55, TreeNode.Sum(1, 10));
            Assert.AreEqual(4950, TreeNode.Sum(1, 99));

            //Q2. Q1코드에서 min max 값이 바뀌어 있으면 어떻게 처리할 것인가.
            Assert.AreEqual(55, TreeNode.MinMaxCheckSum(10, 1));
            Assert.AreEqual(4950, TreeNode.MinMaxCheckSum(99, 1));

            //Q3. Q2코드에서 합값이 int 범위를 넘어갈 때 어떻게 처리할 것인가.
            //Console.WriteLine(TreeNode.TrySum(0, int.MaxValue));
            //Assert.AreEqual(8, TreeNode.TrySum(1, int.MaxValue));

            //Q4. 2^n을 다양한 방법으로 구현하라.
            Assert.AreEqual(8, RecursiveSquare(3));
            Assert.AreEqual(512, RecursiveSquare(9));
            Assert.AreEqual(8, LoopSquare(3));
            Assert.AreEqual(512, LoopSquare(9));
        }

        public static int Sum(int min, int max)
        {
            if (max == min)
            {
                return 1;
            }

            return max + Sum(min, max - 1);
        }

        public static int MinMaxCheckSum(int min, int max)
        {
            if (max == min)
            {
                return 1;
            }

            if (min > max)
            {
                Swap<int>(ref max, ref min);
            }

            return max + Sum(min, max - 1);
        }


        public static int TrySum(int min, int max)
        {
            if (max == min)
            {
                return 1;
            }

            if (min > max)
            {
                Swap<int>(ref max, ref min);
            }

            try
            {
                return max + TrySum(min, max - 1);
            }
            catch
            {
                return 0;
            }
        }

        public static int RecursiveSquare(int cnt)
        {
            if (cnt == 0)
            {
                return 1;
            }

            return 2 * RecursiveSquare(cnt - 1);
        }

        public static int LoopSquare(int cnt)
        {
            int squre = 1;

            for (int i = 0; i < cnt; i++)
            {
                squre *= 2;
            }

            return squre;
        }


        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
