using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{

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
        public void Add(T elem, int key)
        {
            Node<T> node = new Node<T>(elem, key);

            if (root == null) root = node;
            else
            {

                root = BinarySearch(root, node);
            }
        }

        public void Delete()

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

        public int CountNode(Node<T> node) // only left
        {
            int c = 0;
            if (node.Left != null)
            {
                c += 1 + CountNode(node.Left);
            }
            if (node.Right != null)
            {
                c += CountNode(node.Right);
            }

            return c;
        }

        public int SumKeys(Node<T> node)
        {
            int sum = 0;
            if (node.Left != null)
            {
                sum += SumKeys(node.Left);
            }
            if (node.Right != null)
            {
                sum += node.Right.Key + SumKeys(node.Right);
            }

            return sum;
        }
        //It finds the sum of keys in right son nodes in a BBST.

        public void DeleteEven()
        {

        }
    }
}
