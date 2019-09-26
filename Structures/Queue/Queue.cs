using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.Queue
{
    /// <summary>
    /// A queue implementation.
    /// </summary>
    public class Queue<T> : IEnumerable<T>
    {
        private readonly IQueue<T> queue;

        /// <summary>
        /// The number of items in the queue.
        /// </summary>
        public int Count => queue.Count;

        /// <param name="type">The queue implementation type.</param>
        public Queue()
        {
           
                queue = new LinkedListQueue<T>();
        }

        /// <summary>
        /// Time complexity:O(1).
        /// </summary>
        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        /// <summary>
        /// Time complexity:O(1).
        /// </summary>
        public T Dequeue()
        {
            return queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return queue.GetEnumerator();
        }
    }

    

    
}
