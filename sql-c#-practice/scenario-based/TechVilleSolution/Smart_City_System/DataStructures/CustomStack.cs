// File: DataStructures/CustomStack.cs

using System;

namespace SmartCitySmartCity.DataStructures
{
    // LIFO structure with size tracking
    public class CustomStack<T>
    {
        private Node<T> _top;
        public int Count { get; private set; }

        public void Push(T data)
        {
            var newNode = new Node<T>(data);
            newNode.Next = _top;
            _top = newNode;
            Count++;
        }

        public T Pop()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty.");

            var data = _top.Data;
            _top = _top.Next;
            Count--;

            return data;
        }

        public T Peek()
        {
            if (_top == null)
                throw new InvalidOperationException("Stack is empty.");

            return _top.Data;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }

        // Debug helper to visualize stack
        public void Display()
        {
            if (_top == null)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            var current = _top;
            Console.WriteLine("Stack (Top → Bottom):");

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }

            Console.WriteLine($"Total Items: {Count}");
        }
    }
}
