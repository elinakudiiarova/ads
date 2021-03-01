using System;
using System.Collections.Generic;
namespace Lab1_SortedLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var SorLinList = new MySortedLinkedList<string>();
            while (true)
            {
                var elem = Console.ReadLine();
                if (elem == "stop") break;
               SorLinList.AddElement(elem);
            }
            var currentNode = SorLinList.First;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
            
        }
    }
    class MySortedLinkedList<T>
    {
        LinkedList<T> myList = new LinkedList<T>(); // creating linked list

        public LinkedListNode<T> First
        {
            get
            {
                return myList.First;
            }
        }
        public void AddElement(T elem)
        {
            if (myList.Count == 0)
            {
                myList.AddFirst(elem);
            }
            else
            {
                var currentNode = myList.First;
                while (currentNode != null)
                {
                    if (Comparer<T>.Default.Compare(currentNode.Value, elem) == 1)
                    {
                        myList.AddBefore(currentNode, elem);
                        break;
                    }
                    if (currentNode.Next == null)
                    {
                        myList.AddLast(elem);
                        break;
                    }
                    currentNode = currentNode.Next;

                }
            }
        }
    }
}
