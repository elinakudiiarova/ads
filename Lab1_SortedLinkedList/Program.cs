using System;
using System.Collections.Generic;
using System.Linq;
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
                //if (Comparer<T>.Default.Compare(myList.First.Value, elem) == -1 )
                //{

                //}
                //else
                //{
                //    T trail = myList.FindLast(T listEl => Comparer<T>.Default.Compare(listEl, elem) == -1).Value;
                //    myList.AddAfter(trail, elem);

                //}
                var currentNode = myList.First.Next;
                LinkedListNode<T> prevNode = myList.First;
                while (currentNode != null){
                    if(Comparer<T>.Default.Compare(currentNode.Value, prevNode.Value) == -1)
                    {
                        myList.AddBefore(prevNode, elem);
                        break;
                    }
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }
                
                //if (trail == null)
                //{
                //    myList.AddFirst(elem);
                //}
                //else
                //{
                    
                //    myList.AddAfter(trail, elem);
                //}
            }
        }
    }
}
