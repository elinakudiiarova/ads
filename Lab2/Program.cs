using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            var bt = new BBST<string>();
            bt.Add("ten", 10);
            bt.Add("20", 20);
            bt.Add("five", 5);
            bt.Add("30", 30);
            bt.Add("25", 25);
            bt.Add("24", 25);
            Console.WriteLine(bt.Find(5));
            bt.PrintSorted();
            Console.WriteLine(bt.CountNode(bt.Root));
            Console.WriteLine(bt.SumKeys(bt.Root));
            Console.WriteLine(bt.IsBalanced(bt.Root));
            Console.WriteLine(bt.FindSecondLargest());
            bt.DeleteDuplicate();
            bt.DeleteEven();
            
        }
    }


}
