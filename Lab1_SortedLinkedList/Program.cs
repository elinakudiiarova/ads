using System;
using System.Collections.Generic;

namespace Lab1_SortedLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class MySortedLinkedList<T>
    {
        LinkedList<T> myList; // creating linked list

        void AddElement(T elem)
        {
            if (myList.Count == 0)
            {
                myList.AddFirst(elem);
            }
            else
            {
                if (Comparer<T>.Default.Compare(myList.First.Value, elem) == -1 )
                {

                }
                else
                {
                    T trail = myList.FindLast(listEl => listEl < elem).Value;

                }
            }
        }
    }
}
