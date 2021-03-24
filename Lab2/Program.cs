using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Node<T>
    {
        public Node(T data, int key)
        {
            Value = data;
            Key = key;
        }
        public T Value { get; set; }
        public int Key { get; private set; }

        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
    }

    public class BBST<T>
    {
       private Node<T> root;
        public int Height
        {
            get;
            private set;
        } 

        public Node<T> Root
        {
            get
            {
                return root;
            }
        }

        public void Add(T elem, int key)
        {
            Node<T> node = new Node<T>(elem, key);

            if (root == null) root = node;
            else
            {   
                var currentNode = root;
                BinarySearch(currentNode, node);

            }    
        }

        private void BinarySearch(Node<T> currentNode, Node<T> newNode)
        {
            if (currentNode.Key > newNode.Key)
            {
                if(currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                }
                else
                {
                    BinarySearch(currentNode.Left, newNode);
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                }
                else
                {
                    BinarySearch(currentNode.Right, newNode);
                }
            }
        }
    }
}
