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

       
    }
}
