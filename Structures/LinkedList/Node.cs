using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.LinkedList
{
    /// <summary>
    /// This node is for a single linked list -= it is a forward only node;
    /// </summary>
    internal class Node
    {
        internal int data;
        internal Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
}
