using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public bool IsBalanced(Node<T> curNode)
        {
            int dif = Height(curNode.Left) - Height(curNode.Right);
            if (dif >= -1 && dif <= 1)
            {
                return true;
            }
            return false;
        }

        private Node<T> AddCore(Node<T> currentNode, Node<T> newNode)
        {
            if (currentNode.Key > newNode.Key)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                }
                else
                {
                    currentNode.Left = Balance(AddCore(currentNode.Left, newNode));
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
                    currentNode.Right = Balance(AddCore(currentNode.Right, newNode));
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

                root = AddCore(root, node);
            }
        }

        public void Delete(int key)
        {
            Console.WriteLine(key);
            root = DeleteCore(root, key);
        }

        private Node<T> DeleteCore(Node<T> node, int k)
        {
            if (node == null)
            {
                return null;
            }
            if (k < node.Key)
                node.Left = DeleteCore(node.Left, k);
            else if (k > node.Key)
                node.Right = DeleteCore(node.Right, k);
            else //  k == node.Key
            {
                Node<T> l = node.Left;
                Node<T> r = node.Right;
                if (r == null)
                {
                    return l;
                }
                Node<T> min = FindMinInSubtree(r);
                min.Right = RemoveMinInSubtree(r);
                min.Left = l;
                return Balance(min);
            }
            return Balance(node);
        }

        private Node<T> FindMinInSubtree(Node<T> node)
        {
            return node.Left != null ? FindMinInSubtree(node.Left) : node;
        }

        private Node<T> RemoveMinInSubtree(Node<T> node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            node.Left = RemoveMinInSubtree(node.Left);
            return Balance(node);
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

        private List<int> Keys(Node<T> node) {
            var keys = new List<int>();

            if(node == null)
            {
                return keys;
            }
            keys.Add(node.Key);
            keys.AddRange(Keys(node.Left));
            keys.AddRange(Keys(node.Right));
            return keys;
        }

        public void DeleteEven()
        {
            var keys = Keys(root);
            keys.Where(k => k % 2 == 0).ToList().ForEach(k => Delete(k));
        }

        public int FindMiddle()
        {
            var keys = Keys(root);
            keys.Sort();
            int valueMid = (keys.First() + keys.Last()) / 2;
            return keys.OrderBy(key => Math.Abs( valueMid - key)).First();
        }

        public void DeleteDuplicate() {
            var keys = Keys(root);
            keys.GroupBy(elem => elem).Where(elem => elem.Count() > 1).ToList().ForEach(elem => { 
            for(int i = 1; i < elem.Count(); i++)
                {
                    Delete(elem.Key);
                }
            });
        }
        //It deletes all duplicate values from a BBST. (Result is also a BBST with a single value of each key.)

        public int FindSecondLargest()
        {
            var keys = Keys(root);
            return keys.OrderByDescending(k => k).Skip(1).First();
        }
        //It returns the second largest key of a BBST without deleting it.
    }
}
