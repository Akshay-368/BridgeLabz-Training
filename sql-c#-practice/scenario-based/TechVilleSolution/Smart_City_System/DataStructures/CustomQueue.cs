// File: DataStructures/CustomQueue.cs

using System;

namespace SmartCitySmartCity.DataStructures
{
    // FIFO structure with size tracking
    public class CustomQueue<T>
    {
        private Node<T> _front;
        private Node<T> _rear;
        public int Count { get; private set; }

        public void Enqueue(T data)
        {
            var newNode = new Node<T>(data);

            if (_rear == null)
            {
                _front = _rear = newNode;
            }
            else
            {
                _rear.Next = newNode;
                _rear = newNode;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (_front == null)
                throw new InvalidOperationException("Queue is empty.");

            var data = _front.Data;
            _front = _front.Next;

            if (_front == null)
                _rear = null;

            Count--;
            return data;
        }

        public T Peek()
        {
            if (_front == null)
                throw new InvalidOperationException("Queue is empty.");

            return _front.Data;
        }

        public bool IsEmpty()
        {
            return _front == null;
        }

        // Debug helper to visualize queue
        public void Display()
        {
            if (_front == null)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            var current = _front;
            Console.WriteLine("Queue (Front → Rear):");

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }

            Console.WriteLine($"Total Items: {Count}");
        }
    }
}
