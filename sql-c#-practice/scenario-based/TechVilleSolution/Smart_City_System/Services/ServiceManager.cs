// File: Services/ServiceManager.cs

using System;
using SmartCitySmartCity.Models;
using SmartCitySmartCity.DataStructures;

namespace SmartCitySmartCity.Services
{
    public class ServiceManager
    {
        private readonly CustomLinkedList<Service> _services = new();
        private readonly CustomQueue<string> _serviceQueue = new();
        private readonly CustomStack<string> _serviceHistory = new();
        private readonly BinarySearchTree<double> _serviceCostTree = new();
        private readonly Graph _cityRoadNetwork = new();

        public void AddService(Service service)
        {
            if (service == null)
            {
                Console.WriteLine("Invalid service.");
                return;
            }

            _services.Add(service);
            _serviceCostTree.Insert(service.BaseCost);

            Console.WriteLine("Service added successfully.");
        }

        public void DisplayAllServices()
        {
            bool hasData = false;

            _services.Traverse(service =>
            {
                hasData = true;

                Console.WriteLine("----------------------------");
                service.DisplayServiceInfo();

                if (service is PremiumHealthcareService)
                {
                    Console.WriteLine("This is a premium healthcare service.");
                }
            });

            if (!hasData)
            {
                Console.WriteLine("No services available.");
                return;
            }

            Console.WriteLine($"\nTotal Services Created: {Service.GetTotalServices()}");
        }

        // ===============================
        // SERVICE QUEUE OPERATIONS
        // ===============================

        public void AddServiceRequest(string citizenName)
        {
            if (string.IsNullOrWhiteSpace(citizenName))
            {
                Console.WriteLine("Invalid citizen name.");
                return;
            }

            _serviceQueue.Enqueue(citizenName);
            Console.WriteLine("Citizen added to service queue.");
        }

        public void ProcessNextRequest()
        {
            if (_serviceQueue.IsEmpty())
            {
                Console.WriteLine("No pending requests.");
                return;
            }

            var citizen = _serviceQueue.Dequeue();
            _serviceHistory.Push(citizen);

            Console.WriteLine($"Processing service for: {citizen}");
        }

        public void CancelLastService()
        {
            if (_serviceHistory.IsEmpty())
            {
                Console.WriteLine("No processed services to cancel.");
                return;
            }

            var citizen = _serviceHistory.Pop();
            Console.WriteLine($"Cancelled service for: {citizen}");
        }

        public void ShowQueueStatus()
        {
            _serviceQueue.Display();
        }

        public void ShowHistory()
        {
            _serviceHistory.Display();
        }

        // ===============================
        // ROAD NETWORK (GRAPH)
        // ===============================

        public void SetupRoadNetwork()
        {
            _cityRoadNetwork.AddEdge("ZoneA", "ZoneB");
            _cityRoadNetwork.AddEdge("ZoneA", "ZoneC");
            _cityRoadNetwork.AddEdge("ZoneB", "ZoneD");
        }

        public void ShowRoadTraversal(string startZone)
        {
            _cityRoadNetwork.BFS(startZone);
        }

        // ===============================
        // FACTORY METHOD
        // ===============================

        public static Service CreateService(string type, double cost)
        {
            return type.ToLower() switch
            {
                "health" => new HealthcareService(cost, true),
                "education" => new EducationService(cost, "General"),
                _ => null
            };
        }
    }
}
