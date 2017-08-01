using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace MathCollection
{
    public static class MyMathf
    {
        /// <summary>
        /// 大数相加
        /// </summary>
        /// <param name="a">整形</param>
        /// <param name="b">整形</param>
        /// <returns></returns>
        public static string BigAdd(string a, string b)
        {
            if (a == "") return b; if (b == "") return a;       
            int L = a.Length > b.Length ? a.Length : b.Length;
            L += 1;
            a = a.PadLeft(L,'0');
            b = b.PadLeft(L,'0');
            try
            {
                int pre = 0;
                StringBuilder strB = new StringBuilder("");
                for (int i = L - 1; i >= 0; i--)
                {
                    int p = int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + pre;
                    strB.Insert(0, p % 10);
                    pre = p / 10;
                }
                return strB.ToString();
            }
            catch { return "-1"; /*字符串不合格*/ }
        }

        //public static int BinarySearch(int[] arr,int low,int high,int key)
        //{
        //    int middle = (low + high) / 2;
        //    if (low > high)
        //        return -1;
        //    if (arr[middle] == key)
        //        return arr[middle];
        //    else if (arr[middle] > key)
        //    {
        //        high = 
        //    }
        //}
    }

    public class TreeNode
    {
        object value;
        TreeNode leftNode;
        TreeNode rightNode;
    }
}
