using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.LinkedList
{
    public class DoubleNode
    {
        internal int data;
        internal DoubleNode next;
        internal DoubleNode previous;

        public DoubleNode(int d)
        {
            data = d;
            previous = null;
            next = null;
        }
    }
}
