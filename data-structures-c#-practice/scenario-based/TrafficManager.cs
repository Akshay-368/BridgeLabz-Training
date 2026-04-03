using System;

namespace SmartCityTrafficManagement
{

    // DATA MODELS & NODES

    /// Represents a Vehicle in the system.
    /// Relationship: The Node "Has-a" Vehicle.
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }

        public Vehicle(string licensePlate, string vehicleType)
        {
            LicensePlate = licensePlate;
            VehicleType = vehicleType;
        }

        public override string ToString() => $"[{VehicleType}: {LicensePlate}]"; // expression-bodied method ( or fat arrow ) or lambda arrow or 
    }


    /// Custom Node for Circular Linked List.

    public class RoundaboutNode
    {
        public Vehicle Data { get; set; }
        public RoundaboutNode Next { get; set; }

        public RoundaboutNode(Vehicle vehicle)
        {
            Data = vehicle;
        }
    }


    // ABSTRACTIONS (CONTRACTS)

    /// Interface defining the behavior contract.

    public interface ITrafficController
    {
        void ProcessVehicleEntry();
        void ProcessVehicleExit();
        void DisplayCurrentStatus();
    }

    /// Abstract Base Class handling Central Storage.
    /// Principles: Encapsulation (protected fields), DRY (shared display logic).

    public abstract class RoundaboutBase : ITrafficController
    {
        // Centralized Storage (Encapsulated for derived classes)
        protected RoundaboutNode headPointer = null;
        protected RoundaboutNode tailPointer = null;
        
        // Custom Queue using Array 
        protected Vehicle[] waitingQueue;
        protected int queueFront = -1;
        protected int queueRear = -1;
        protected int maxQueueCapacity;
        protected int currentRoundaboutCount = 0;

        protected RoundaboutBase(int queueSize)
        {
            this.maxQueueCapacity = queueSize;
            this.waitingQueue = new Vehicle[queueSize];
        }

        // Abstract methods for child-specific logic (KISS/YAGNI)
        public abstract void ProcessVehicleEntry();
        public abstract void ProcessVehicleExit();

        // Shared Logic: Display Roundabout State
        public void DisplayCurrentStatus()
        {
            Console.WriteLine(" Current Roundabout State ");
            if (headPointer == null)
            {
                Console.WriteLine("Roundabout is empty.");
            }
            else
            {
                RoundaboutNode temp = headPointer;
                do
                {
                    Console.Write($"{temp.Data} -> ");
                    temp = temp.Next;
                } while (temp != headPointer);
                Console.WriteLine("(Back to Start)");
            }
            DisplayQueueStatus();
        }

        private void DisplayQueueStatus()
        {
            Console.WriteLine("Waiting Queue: ");
            if (queueFront == -1) Console.WriteLine("[Empty]");
            else
            {
                for (int i = queueFront; i <= queueRear; i++)
                    Console.Write($"{waitingQueue[i]} ");
                Console.WriteLine();
            }
        }
    }

    //  CONCRETE IMPLEMENTATION

    /// Concrete Manager. 
    /// Relationship: SmartTrafficManager "Is-a" RoundaboutBase.
    /// Relationship: RoundaboutBase "Has-a" Circular Linked List and Queue.

    public class SmartTrafficManager : RoundaboutBase
    {
        public SmartTrafficManager(int queueSize) : base(queueSize) { }

        public override void ProcessVehicleEntry()
        {
            Console.Write("Enter Vehicle License Plate: ");
            string plate = Console.ReadLine() ?? "DEFAULT-000";
            Console.Write("Enter Vehicle Type (Car/Truck/Bus): ");
            string type = Console.ReadLine() ?? "Car";

            Vehicle newVehicle = new Vehicle(plate, type);

            // Logic: If roundabout is "full" (business rule: e.g., 5 cars), add to queue
            if (currentRoundaboutCount >= 5)
            {
                EnqueueToWaitingArea(newVehicle);
            }
            else
            {
                AddToCircularPath(newVehicle);
            }
        }

        private void AddToCircularPath(Vehicle vehicle)
        {
            RoundaboutNode newNode = new RoundaboutNode(vehicle);
            if (headPointer == null)
            {
                headPointer = newNode;
                tailPointer = newNode;
                newNode.Next = headPointer;
            }
            else
            {
                tailPointer.Next = newNode;
                tailPointer = newNode;
                tailPointer.Next = headPointer; // Maintain Circularity
            }
            currentRoundaboutCount++;
            Console.WriteLine($"Action: {vehicle.LicensePlate} entered the roundabout.");
        }

        private void EnqueueToWaitingArea(Vehicle vehicle)
        {
            if (queueRear == maxQueueCapacity - 1)
            {
                Console.WriteLine("CRITICAL: Waiting Queue Overflow! Vehicle must take another route.");
                return;
            }
            if (queueFront == -1) queueFront = 0;
            waitingQueue[++queueRear] = vehicle;
            Console.WriteLine($"Action: Roundabout full. {vehicle.LicensePlate} moved to Waiting Queue.");
        }

        public override void ProcessVehicleExit()
        {
            if (headPointer == null)
            {
                Console.WriteLine("Underflow: No vehicles to remove from roundabout.");
                return;
            }

            Console.WriteLine($"Action: {headPointer.Data.LicensePlate} exited the roundabout.");

            if (headPointer == tailPointer)
            {
                headPointer = null;
                tailPointer = null;
            }
            else
            {
                headPointer = headPointer.Next;
                tailPointer.Next = headPointer; // Maintain Circularity
            }
            currentRoundaboutCount--;

            // Pull from Queue if available
            if (queueFront != -1)
            {
                Vehicle nextVehicle = waitingQueue[queueFront];
                // Shift Queue (Simple Array Shift for KISS)
                if (queueFront == queueRear) queueFront = queueRear = -1;
                else queueFront++;

                Console.WriteLine("Queue Update: Next vehicle from queue entering roundabout...");
                AddToCircularPath(nextVehicle);
            }
        }
    }


    //  MAIN EXECUTION
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Smart Roundabout Traffic System ");
            
            // Ask for user input with a default fallback
            Console.Write("Enter Max Waiting Queue Capacity (Default 3): ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int capacity)) capacity = 3;

            // Using Interface for Polymorphism
            ITrafficController manager = new SmartTrafficManager(capacity);

            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Vehicle Entry | 2. Vehicle Exit | 3. Show State | 4. Exit");
                Console.Write("Select Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": manager.ProcessVehicleEntry(); break;
                    case "2": manager.ProcessVehicleExit(); break;
                    case "3": manager.DisplayCurrentStatus(); break;
                    case "4": running = false; break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
    }
}
