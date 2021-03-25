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
            Console.WriteLine(bt.IsBalanced(bt.Root));
            Console.WriteLine(bt.Find(5));
            bt.PrintSorted();
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

        public override string ToString() => $"{Key} = {Value}";
    }

    public class BBST<T>
    {
        private Node<T> root;

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

                root = BinarySearch(root, node);
            }
        }

        private Node<T> RotateRight(Node<T> node)
        {
            // правый поворот вокруг p
            {
                Node<T> q = node.Left;
                node.Left = q.Right;
                q.Right = node;
                return q;
            }
        }

        private Node<T> RotateLeft(Node<T> node) // левый поворот вокруг q
        {
            Node<T> p = node.Right;
            node.Right = p.Left;
            p.Left = node;
            return p;
        }
        private Node<T> BinarySearch(Node<T> currentNode, Node<T> newNode)
        {
            if (currentNode.Key > newNode.Key)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                }
                else
                {
                    currentNode.Left = Balance(BinarySearch(currentNode.Left, newNode));
                }
                return Balance(currentNode);
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                }
                else
                {
                    currentNode.Right = Balance(BinarySearch(currentNode.Right, newNode));
                }
                return Balance(currentNode);
            }
        }

        private Node<T> Balance(Node<T> node)
        {
            if (BFactor(node) == 2)
            {
                if (BFactor(node.Right) < 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            if (BFactor(node) == -2)
            {
                if (BFactor(node.Left) > 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            return node; // балансировка не нужна
        }

        private int BFactor(Node<T> node)
        {
            return Height(node.Right) - Height(node.Left);
        }

        public bool IsBalanced(Node<T> curNode)
        {
            int dif = Height(curNode.Left) - Height(curNode.Right);
            if (dif >= -1 && dif <= 1)
            {
                return true;
            }
            return false;
        }

        private int Height(Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }
            else
            {
                int left = Height(currentNode.Left);
                int rDepth = Height(currentNode.Right);

                if (left > rDepth)
                {
                    return left + 1;
                }
                else
                {
                    return rDepth + 1;
                }
            }
        }


        public T Find(int key)
        {
            var currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.Key == key)
                {
                    return currentNode.Value;
                }
                if (currentNode.Key > key)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
            throw new Exception("Can't find key");
        }

        public void PrintSorted()
        {
            Console.WriteLine(PrintAscending(root));
            Console.WriteLine(PrintDescending(root));
        }

        private string PrintDescending(Node<T> node)
        {
            return $"{(node.Right == null ? "" : PrintDescending(node.Right))} {node.Key} {(node.Left == null ? "" : PrintDescending(node.Left))}";

        }
        private string PrintAscending(Node<T> node)
        {
            return $"{(node.Left == null ? "" : PrintAscending(node.Left))} {node.Key} {(node.Right == null ? "" : PrintAscending(node.Right))}";

        }

        //public int CountNode()
        //{
        //    //. It count the number of left son nodes in a BBST
        //}
    }
}
