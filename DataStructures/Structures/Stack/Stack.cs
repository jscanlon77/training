using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Structures.Stack
{
    internal interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }
        T Pop();
        void Push(T item);
        T Peek();
    }
    // Implementation of a stack with a linked list
    public class Stack<T> : IEnumerable<T>
    {
        private readonly IStack<T> stack;
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Count => stack.Count;

        public Stack()
        {
            stack = new LinkedListStack<T>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
