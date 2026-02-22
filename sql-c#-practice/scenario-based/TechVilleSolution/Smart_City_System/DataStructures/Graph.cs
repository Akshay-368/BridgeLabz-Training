// File: DataStructures/Graph.cs

using System;
using System.Collections.Generic;

namespace SmartCitySmartCity.DataStructures
{
    // Undirected graph using adjacency list
    public class Graph
    {
        private readonly Dictionary<string, List<string>> _adjacencyList = new();

        public void AddVertex(string vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
                _adjacencyList[vertex] = new List<string>();
        }

        public void AddEdge(string source, string destination)
        {
            AddVertex(source);
            AddVertex(destination);

            _adjacencyList[source].Add(destination);
            _adjacencyList[destination].Add(source); // Undirected
        }

        public void Display()
        {
            foreach (var vertex in _adjacencyList)
            {
                Console.Write($"{vertex.Key} → ");
                Console.WriteLine(string.Join(", ", vertex.Value));
            }
        }

        // Breadth First Search
        public void BFS(string startVertex)
        {
            if (!_adjacencyList.ContainsKey(startVertex))
            {
                Console.WriteLine("Start vertex not found.");
                return;
            }

            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            visited.Add(startVertex);
            queue.Enqueue(startVertex);

            Console.WriteLine("BFS Traversal:");

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex);

                foreach (var neighbor in _adjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
