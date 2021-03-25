using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
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
}
