// File: DataStructures/Node.cs

namespace SmartCitySmartCity.DataStructures
{
    // Generic node for flexible data storage
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
