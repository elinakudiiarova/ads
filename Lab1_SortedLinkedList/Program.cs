using System;
using System.Collections.Generic;
namespace Lab1_SortedLinkedList
{
    class Program
    {
        static void Main()
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
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class MySortedLinkedList<T> : IEnumerable<T>  // односвязный список
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int Count;  // количество элементов в списке


            private int myVar;

        MySortedLinkedList<T> myList = new MySortedLinkedList<T>();
        public LinkedListNode<T> First
        {
            get
            {
                return myList.First;
            }
        }

        public int Count // 
        {
            get
            {
                return myList.Count;
            }
        }

        public int FindElement(T elem)
        {
            int resultInd = -1;
            while (true)
            {
                if (myList.Contains(elem))
                {

                }
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
