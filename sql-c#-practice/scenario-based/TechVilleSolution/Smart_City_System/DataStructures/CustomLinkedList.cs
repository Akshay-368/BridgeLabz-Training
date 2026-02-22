// File: DataStructures/CustomLinkedList.cs

using System;

namespace SmartCitySmartCity.DataStructures
{
    // Simple singly linked list implementation
    public class CustomLinkedList<T>
    {
        private Node<T> _head;

        public void Add(T data)
        {
            var newNode = new Node<T>(data);

            if (_head == null)
            {
                _head = newNode;
                return;
            }

            var current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public void Remove(T data)
        {
            if (_head == null)
                return;

            if (_head.Data.Equals(data))
            {
                _head = _head.Next;
                return;
            }

            var current = _head;

            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    return;
                }

                current = current.Next;
            }
        }

        public bool Contains(T data)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public void Traverse(Action<T> action)
        {
            var current = _head;

            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }
}
