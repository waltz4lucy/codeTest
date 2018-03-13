using System;

namespace codeTest
{
    public class TreeNode
    {
        public TreeNode()
        {
            //TODO: 코드 테스트 Assert로 리팩토링

            //Q1. 반복문을 사용하지 않고 정수 n1 ~ n2 합을 구하라.
            Console.WriteLine(55 == TreeNode.Sum(1, 10));
            Console.WriteLine(4950 == TreeNode.Sum(1, 99));

            //Q2. Q1코드에서 min max 값이 바뀌어 있으면 어떻게 처리할 것인가.
            Console.WriteLine(55 == TreeNode.MinMaxCheckSum(10, 1));
            Console.WriteLine(4950 == TreeNode.MinMaxCheckSum(99, 1));

            //Q3. Q2코드에서 합값이 int 범위를 넘어갈 때 어떻게 처리할 것인가.
            Console.WriteLine(TreeNode.TrySum(0, int.MaxValue));

            //Q4. 2^n을 다양한 방법으로 구현하라.
            Console.WriteLine((int)Math.Pow(2, 3) == RecursiveSquare(3));
            Console.WriteLine((int)Math.Pow(2, 9) == RecursiveSquare(9));
            Console.WriteLine((int)Math.Pow(2, 3) == LoopSquare(3));
            Console.WriteLine((int)Math.Pow(2, 9) == LoopSquare(9));
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
