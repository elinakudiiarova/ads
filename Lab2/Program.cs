﻿using System;
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
            Console.WriteLine(bt.IsBalanced(bt.Root));
            Console.WriteLine(bt.Find(5));
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
                if(IsBalanced(currentNode) == false)
                {
                    
                }
            }
        }



        public bool IsBalanced(Node<T> curNode)
        {
            int dif = Height(curNode.Left) - Height(curNode.Right);
            if(dif >= -1 && dif <= 1)
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

            private void BinarySearch(Node<T> currentNode, Node<T> newNode)
            {
                if (currentNode.Key > newNode.Key)
                {
                    if (currentNode.Left == null)
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
        }
    }
