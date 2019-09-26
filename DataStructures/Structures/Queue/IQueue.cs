using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.Queue
{
    internal interface IQueue<T> : IEnumerable<T>
    {
        int Count { get; }
        void Enqueue(T item);
        T Dequeue();
    }
}
