// All classes are defined in this single file as per requirements.

// StageNode class: This is a custom class for nodes in the singly linked list.
// Relationship: StageNode has-a String (stageName) for storing the stage description (composition, essential for identifying the stage).
// StageNode has-a StageNode (next) for linking to the next stage (composition, essential for forming the chain in the singly linked list).
// Why: This enables the forward traversal required for tracking stages without using any built-in collections, only custom nodes with pointers.
class StageNode {
    private String stageName; // Encapsulation: private to control access.
    protected StageNode next; // Protected: allows subclasses of the tracker to access if needed for customization.

    public StageNode(String name) {
        stageName = name;
        next = null;
    }

    // Getter for encapsulation.
    public String getStageName() {
        return stageName;
    }

    // Setter for encapsulation, allowing modification if needed.
    public void setStageName(String name) {
        stageName = name;
    }
}

// ParcelTrackerInterface: Defines the contract for all parcel trackers.
// Relationship: This is an interface that the abstract base class will implement (is-a relationship for polymorphism).
// Why: To enforce a common contract as per OOP principles (SOLID: Interface Segregation, allows for multiple implementations).
interface ParcelTrackerInterface {
    void initializeStages();
    void addCheckpoint(String newStage, String afterStage);
    void trackForward();
    void handleLostParcel(String atStage);
}

// AbstractParcelTracker: Abstract base class implementing the interface.
// Relationship: AbstractParcelTracker is-a ParcelTrackerInterface (inheritance, essential for providing common behavior while allowing customization).
// AbstractParcelTracker has-a StageNode (head) for central storage of the linked list (composition, essential as it centralizes the chain management).
// AbstractParcelTracker has-a String (parcelId) for identifying the parcel (composition, essential for tracking specific parcels).
// Why: Centralizes common logic (DRY principle), uses inheritance for shared properties, follows SOLID (Open-Closed: extendable via children, Liskov Substitution: children can replace it).
// Encapsulation: Fields are protected for subclass access. Constructors pass non-primitive types if needed, but here primitives are fine.
abstract class AbstractParcelTracker implements ParcelTrackerInterface {
    protected StageNode head; // Central storage for the linked list chain.
    protected String parcelId; // Identifier for the parcel.

    public AbstractParcelTracker(String id) {
        parcelId = id;
        head = null;
    }

    // Common helper method to find a stage node by name.
    // Uses if-else for checks instead of exceptions.
    protected StageNode findStage(String stageName) {
        StageNode current = head;
        while (current != null) {
            if (current.getStageName().equals(stageName)) {
                return current;
            }
            current = current.next;
        }
        return null; // Returns null if not found (handles null pointers).
    }

    // Common implementation for adding a checkpoint.
    // Follows KISS: Simple insertion logic.
    @Override
    public void addCheckpoint(String newStage, String afterStage) {
        if (head == null) {
            System.out.println("No stages initialized.");
            return;
        }
        StageNode afterNode = findStage(afterStage);
        if (afterNode == null) {
            System.out.println("After stage not found. Cannot add checkpoint.");
            return;
        }
        StageNode newNode = new StageNode(newStage);
        newNode.next = afterNode.next;
        afterNode.next = newNode;
        System.out.println("Added checkpoint: " + newStage + " after " + afterStage);
    }

    // Common implementation for forward tracking.
    // Traverses the list and prints the chain.
    @Override
    public void trackForward() {
        if (head == null) {
            System.out.println("No stages to track.");
            return;
        }
        StageNode current = head;
        System.out.print("Tracking parcel " + parcelId + ": ");
        while (current != null) {
            System.out.print(current.getStageName() + " -> ");
            current = current.next;
        }
        System.out.println("End");
    }

    // Common implementation for handling lost parcel.
    // Sets next to null to simulate null pointer for lost/missing.
    @Override
    public void handleLostParcel(String atStage) {
        if (head == null) {
            System.out.println("No stages initialized.");
            return;
        }
        StageNode atNode = findStage(atStage);
        if (atNode == null) {
            System.out.println("Stage not found. Cannot handle lost.");
            return;
        }
        atNode.next = null;
        System.out.println("Parcel " + parcelId + " marked as lost after " + atStage + " (null pointer set).");
    }

    // Abstract method: Children must implement their own stage initialization.
    // Allows overriding/customization in children.
    @Override
    public abstract void initializeStages();
}

// StandardParcelTracker: Child class for standard delivery.
// Relationship: StandardParcelTracker is-a AbstractParcelTracker (inheritance, essential for specializing the standard flow).
// Why: Provides specific implementation for initializeStages, follows SOLID (Single Responsibility: handles standard stages only).
class StandardParcelTracker extends AbstractParcelTracker {
    public StandardParcelTracker(String id) {
        super(id);
    }

    // Overrides to implement standard stages: Packed -> Shipped -> In Transit -> Delivered.
    @Override
    public void initializeStages() {
        head = new StageNode("Packed");
        head.next = new StageNode("Shipped");
        head.next.next = new StageNode("In Transit");
        head.next.next.next = new StageNode("Delivered");
        System.out.println("Initialized standard stages for parcel " + parcelId);
    }

    // Optional override example: Customizes trackForward for standard (adds extra info).
    @Override
    public void trackForward() {
        System.out.print("Standard ");
        super.trackForward(); // Calls parent for DRY.
    }
}

// ExpressParcelTracker: Second child class for express delivery.
// Relationship: ExpressParcelTracker is-a AbstractParcelTracker (inheritance, essential for specializing the express flow).
// Why: Provides different implementation for initializeStages (skips some stages), demonstrates overriding, follows YAGNI (only what's needed).
class ExpressParcelTracker extends AbstractParcelTracker {
    public ExpressParcelTracker(String id) {
        super(id);
    }

    // Overrides to implement express stages: Packed -> Shipped -> Delivered (skips In Transit).
    @Override
    public void initializeStages() {
        head = new StageNode("Packed");
        head.next = new StageNode("Shipped");
        head.next.next = new StageNode("Delivered");
        System.out.println("Initialized express stages for parcel " + parcelId);
    }

    // Optional override example: Customizes handleLostParcel for express (adds express-specific message).
    @Override
    public void handleLostParcel(String atStage) {
        super.handleLostParcel(atStage); // Calls parent for DRY.
        System.out.println("Express delivery: Urgent notification sent for lost parcel.");
    }
}

// Main class to demonstrate.
// Only main is static as necessary.
// Uses Scanner for user input with defaults.
public class ParcelTrackerDemo {
    public static void main(String[] args) {
        java.util.Scanner scanner = new java.util.Scanner(System.in);

        // Ask for parcel ID with default.
        System.out.print("Enter parcel ID (default: P001): ");
        String parcelId = scanner.nextLine();
        if (parcelId.isEmpty()) {
            parcelId = "P001";
        }

        // Ask for tracker type with default.
        System.out.print("Enter tracker type (standard or express, default: standard): ");
        String type = scanner.nextLine();
        if (type.isEmpty()) {
            type = "standard";
        }

        ParcelTrackerInterface tracker;
        if (type.equalsIgnoreCase("express")) {
            tracker = new ExpressParcelTracker(parcelId);
        } else {
            tracker = new StandardParcelTracker(parcelId);
        }

        // Initialize stages.
        tracker.initializeStages();

        // Demonstrate tracking.
        tracker.trackForward();

        // Ask for adding checkpoint.
        System.out.print("Enter new checkpoint name (default: At Warehouse): ");
        String newStage = scanner.nextLine();
        if (newStage.isEmpty()) {
            newStage = "At Warehouse";
        }
        System.out.print("Enter after which stage (default: Shipped): ");
        String afterStage = scanner.nextLine();
        if (afterStage.isEmpty()) {
            afterStage = "Shipped";
        }
        tracker.addCheckpoint(newStage, afterStage);

        // Track again.
        tracker.trackForward();

        // Ask for lost stage.
        System.out.print("Enter stage where lost (default: In Transit): ");
        String lostStage = scanner.nextLine();
        if (lostStage.isEmpty()) {
            lostStage = "In Transit";
        }
        tracker.handleLostParcel(lostStage);

        // Track after lost.
        tracker.trackForward();

        scanner.close();
    }
}
