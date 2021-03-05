using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
               SorLinList.Add(elem);
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
            Value = data;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    public class MySortedLinkedList<T> : IEnumerable<T>  // creating class for our list
    {
        Node<T> head; // firstElem
        public int Count
        {
            get;
            private set;
        } // length of List

        // first elem 
        public Node<T> First
        {
            get;
            private set;
        }

        // сreating indexator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        private IEnumerable<Node<T>> Nodes()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }


        public void AddBefore(Node<T> NodeBeforeElem, T elem)
        {
            var newNode = new Node<T>(data: elem);
            newNode.Next = NodeBeforeElem.Next;
            NodeBeforeElem.Next = newNode;
            
        }
  
        public void Add(T elem)
        {
            Node<T> node = new Node<T>(elem);

            if (head == null) head = node;
            else
            {
                var currentNode = head;
                Node<T> nodeBeforeCur = null;
                while( currentNode != null)
                {
                    if(Comparer<T>.Default.Compare(currentNode.Value, elem) == 1)
                    {
                        if (nodeBeforeCur == null) 
                            AddBefore(currentNode, elem); 
                        else 
                            AddBefore(nodeBeforeCur, elem);
                        break;
                    }
             
                   if (currentNode.Next == null)
                   {
                    currentNode.Next = new Node<T>(elem);
                    break;
                   }
                    nodeBeforeCur = currentNode;
                   currentNode = currentNode.Next;

                }
            }
            Count++;
        }

        //public void AddElement(T elem)
        //{
        //    //if (myList.Count == 0)
        //    //{
        //    //    myList.AddFirst(elem);
        //    //}
        //    else
        //    {
        //        //var currentNode = myList.First;
        //    //    while (currentNode != null)
        //    //    {
        //    //        if (Comparer<T>.Default.Compare(currentNode.Value, elem) == 1)
        //    //        {
        //    //            myList.AddBefore(currentNode, elem);
        //    //            break;
        //    //        }
        //    //        if (currentNode.Next == null)
        //    //        {
        //    //            myList.AddLast(elem);
        //    //            break;
        //    //        }
        //    //        currentNode = currentNode.Next;

        //    //    }
        //    //}
        //}
    }
}
