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
            
            var firElem = Console.ReadLine();
            if (int.TryParse(firElem, out var firstInt))
            {
                var SorLinList = new MySortedLinkedList<int>();
                SorLinList.Add(firstInt);
                while (true)
                {
                    var elem = Console.ReadLine();
                    if (elem == "stop")
                        break;
                    SorLinList.Add(int.Parse(elem));
                }
                Console.WriteLine($"List length: {SorLinList.Count}");
                SorLinList.ListOutput();
            }
            else if (decimal.TryParse(firElem, out var first))
            {
                var SorLinList = new MySortedLinkedList<decimal>();
                SorLinList.Add(first);
                while (true)
                {
                    var elem = Console.ReadLine();
                    if (elem == "stop")
                        break;
                    SorLinList.Add(decimal.Parse(elem));
                }
                Console.WriteLine($"List length: {SorLinList.Count}");
                SorLinList.ListOutput();
            }
            else
            {
                var SorLinList = new MySortedLinkedList<string>();
                SorLinList.Add(firElem);
                while (true)
                {
                    var elem = Console.ReadLine();
                    if (elem == "stop")
                        break;
                    SorLinList.Add(elem);
                }
                Console.WriteLine($"List length: {SorLinList.Count}");
                SorLinList.ListOutput();
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
                get
                {
                    return head;
                }
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
            // LIST SERACH 

            public int SearchElem(T elem)
            {
                var currentNode = First;
                var numbOfCurElement = 0;
                while (currentNode != null)
                {
                    if(Comparer<T>.Default.Compare(currentNode.Value, elem) == 0) { return numbOfCurElement;}
                    currentNode = currentNode.Next;
                }
                return -1;
            
            }
                             
            // listOutputing
            public void ListOutput()
            {
                var currentNode = First;
                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.Value);
                    currentNode = currentNode.Next;
                }
            }

            // is list is full
            public bool IsEmpty()
            {
                if (Count == 0) 
                    return true;
                else
                    return false;
            }
            
            // deleteItem 

            public void DeleteElem(T elemToDelete)
            {
                var currentNode = First;
                Node<T> previousNode = null;
                while (currentNode != null)
                {
                    if (Comparer<T>.Default.Compare(currentNode.Value, elemToDelete) == 0) {
                        if (previousNode != null && currentNode != null)
                        { previousNode.Next = currentNode.Next; }
                        else if () { }
                    } 
                    previousNode = currentNode;
                    currentNode = currentNode.Next; 
                } 
  
            }
            public void AddAfter(Node<T> NodeBeforeElem, T elem)
            {
                var newNode = new Node<T>(data: elem);
                newNode.Next = NodeBeforeElem.Next;
                NodeBeforeElem.Next = newNode;
                Count++;
            }

            public void AddFirst( T elem)
            {
                var newNode = new Node<T>(elem);
                newNode.Next = head;
                head = newNode;
                Count++;
            }
            public void Add(T elem)
            {
                Node<T> node = new Node<T>(elem);

                if (head == null) head = node;
                else
                {
                    var currentNode = head;
                    Node<T> nodeBeforeCur = null;
                    while (currentNode != null)
                    {
                        if (Comparer<T>.Default.Compare(currentNode.Value, elem) == 1)
                        {
                            if (nodeBeforeCur == null)
                            {
                                node.Next = head;
                                head = node;
                            }
                            else
                            {
                                AddAfter(nodeBeforeCur, elem);
                                return;
                            }

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


            public void InsertDuplicate()
            {
                Node<T> previousNode = null;
                foreach ( Node<T> node in Nodes())
                {
                    if (previousNode == null && node.Next == null)
                    {
                        Add(node.Value);
                    }
                   else if (previousNode == null)
                    {
                        if (Comparer<T>.Default.Compare(node.Value, node.Next.Value) != 0)
                        {
                            AddFirst(node.Value);
                        }
                       
                    }
                    else if(node.Next == null)
                    {
                        if (Comparer<T>.Default.Compare(node.Value, previousNode.Value) != 0)
                        {
                            AddAfter(node, node.Value);
                        }
                    }
                    else
                    {
                        if (Comparer<T>.Default.Compare(node.Value, previousNode.Value) != 0
                           && Comparer<T>.Default.Compare(node.Value, node.Next.Value) != 0)
                        {
                            AddAfter(previousNode, node.Value);
                        }
                    }
                    previousNode = node;
                }
            }
        }
    }
}
