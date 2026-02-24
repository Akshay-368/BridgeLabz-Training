# BridgeLabz-Training
# Training Program Workflow

Welcome to the documentation of my training program workflow! This record will be continuously updated with a work summary and detailed explanations of tasks and topics covered during the program.

## Day-wise Summary

### Date: December 18, 2025 | Day: 1

#### Topics Covered:
1. **History of C# and .NET**
   - We discussed the evolution and development of C# and the .NET framework, touching upon the key milestones and how .NET has matured to support multiple languages and platforms. 
   - C# was compared with other languages like Java to understand scenarios where it outperforms, e.g., speed and modern features.

2. **Installation of .NET Version 8.0.416**
   - Learned the process to download and install the latest version of .NET (8.0.416).
   - Tested and verified the installation by running basic commands.

3. **Interpreter vs Compiler**
   - Gained clarity on the difference between interpreters and compilers:
     - Interpreter: Executes code line-by-line.
     - Compiler: Translates the entire code to machine-level language before execution.
   - Learned how C# utilizes a "compiler" and follows a "top-to-bottom" execution flow.

4. **MSLI and LI**
   - Explored the concept of MSLI (Microsoft Intermediate Language) and how it works alongside IL (Interpreted Language).

5. **Git Commands and Workflow**
   - Learned to:
     - Clone a repository.
     - Rename a directory.
     - Work on a branch other than the default (e.g., `core-c#-practice`).
   - Practiced basic Git commands for managing repositories and branching workflows.

6. **C# vs Java (Performance & Security)**
   - Discussed performance metrics of C#, highlighting scenarios where it is faster than Java.
   - Understood why Java is preferred for enterprise-level projects with higher security requirements.

#### Practical Tasks:
- Wrote and executed **10 basic C# programs** to practice fundamental concepts.

  **Programs:**
  1. Calculate the area of a circle.
  2. Calculate the volume of a cylinder.
  3. Compute simple interest.
  4. Print the sum of two numbers.
  5. Calculate the average of three numbers.
  6. Perimeter of a rectangle.
  7. Power calculation (base and exponent).
  8. Conversion from kilometers to miles.
  9. "Hello, World!" program.
  10. Conversion of temperature from Celsius to Fahrenheit.

  **Key Learnings from Practical Tasks:**
  - Applied mathematical formulas to solve real-world problems using C#.
  - Gained hands-on experience with variable declaration, data types, I/O operations, and mathematical operations.

---

### Date: December 19, 2025 | Day: 2

#### Topics Covered:
1. **Monolithic Architecture**
   - Overview of a monolithic application: single deployable unit where UI, business logic, and data access are packaged together.
   - Pros: simpler deployment, easier to develop small apps; Cons: harder to scale, maintain, and evolve for large systems.

2. **3-Layer Architecture (Presentation / Business / Data)**
   - Explanation of the three layers:
     - Presentation Layer — UI and user interaction.
     - Business Logic Layer — domain rules, validation, core application logic.
     - Data Access Layer — persistence, repositories, DB access.
   - Benefits: separation of concerns, easier testing and maintenance, clearer boundaries for refactoring.

3. **F# vs C#**
   - F#: functional-first language on .NET, great for concise code, immutability, algebraic data types, and domain modeling.
   - C#: object-oriented and multi-paradigm, strong tooling, wide ecosystem, and common choice for enterprise apps.
   - When to choose: use F# for functional-heavy tasks (data transformation, domain modeling), C# for general-purpose and existing OOP codebases.

4. **Features of C#**
   - Type safety, garbage collection, rich standard library, LINQ, async/await, generics, pattern matching, nullable reference types, records, tuples, and strong tooling (Roslyn).
   - Interoperability with other .NET languages and native libraries.

5. **C# vs Java**
   - Similarities: both strongly-typed, managed runtimes, large ecosystems.
   - Differences:
     - Language features: C# often introduces language features faster (e.g., LINQ, async/await, records).
     - Interop: C# integrates tightly with Windows/.NET ecosystem; Java is historically more platform-agnostic across JVM implementations.
     - Performance: depends on workload and runtime; modern .NET and JVM both perform well with different trade-offs.

6. **CIL / MSIL / IL**
   - IL (Intermediate Language) is the CPU-independent instruction set used by .NET.
   - MSIL (Microsoft Intermediate Language) is the historical Microsoft term; CIL (Common Intermediate Language) is the standardized name (ECMA).
   - Source code in C# is compiled into IL/CIL/MSIL before being converted to native code by the runtime.

7. **Common Language Runtime (CLR)**
   - CLR provides services such as memory management (GC), type safety, exception handling, security, and JIT compilation.
   - Hosts the execution of managed code and provides cross-language interoperability.

8. **Two-stage compilation in C# (and toolchain notes)**
   - Typical flow:
     - C# compiler (Roslyn / csc) compiles .cs files into assemblies containing IL.
     - At runtime, the JIT (e.g., RyuJIT) compiles IL to native machine code on demand.
   - Additional options: Ahead-of-Time (AOT) compilation and ReadyToRun images are available in newer .NET releases for startup/perf improvements.

9. **Programs in C#**
   - Covered sample programs (see Day 1) and planned exercises to demonstrate:
     - Layered architecture patterns (simple three-tier demo).
     - Small F# vs C# snippets to compare style and syntax.
     - Examples showing IL generation and inspecting assemblies.

10. **Operators in C#**
    - Categories covered:
      - Arithmetic: +, -, *, /, %, ++, --.
      - Relational: ==, !=, >, <, >=, <=.
      - Logical: &&, ||, !.
      - Bitwise: &, |, ^, ~, <<, >>.
      - Assignment: =, +=, -=, etc.
      - Other: ternary (?:), null-coalescing (??) ( only in newer versions and not in current version that the trainer recommended to use during this training ), pattern-related operators.

11. **Data Types in C#**
    - Value types: int, long, short, byte, float, double, decimal, bool, char, struct, enum.
    - Reference types: string, class, interface, delegate, object, arrays.
    - Nullable types: `int?`, nullable reference types annotations (C# 8+).

12. **Access Modifiers in C#**
    - We covered the six access modifiers and implemented a simple demonstration program.
    - The six modifiers:
      1. `public` — accessible from anywhere.
      2. `private` — accessible only within the containing type.
      3. `protected` — accessible within the containing type and types derived from it.
      4. `internal` — accessible anywhere within the same assembly.
      5. `protected internal` — accessible from derived types OR anywhere in the same assembly.
      6. `private protected` — accessible from derived types, but only within the same assembly (introduced in C# 7.2).
    - Notes:
      - `internal` is useful for hiding implementation from other assemblies.
      - `protected internal` and `private protected` give finer-grained control for library authors.
      - `private protected` differs from `protected internal`: `private protected` requires both derived and same-assembly conditions; `protected internal` requires only one.

#### Key Learnings:
- Understood application architecture choices (monolithic vs layered) and when to use each.
- Clarified the .NET compilation pipeline and terminology (IL / CIL / MSIL, CLR).
- Saw practical differences between F# and C# and learned the major language features of C#.
- Gained hands-on practice with operators, data types, and building simple layered applications.


---

### Date: December 20, 2025 | Day: 3

#### Activities & Review:

1. **Consolidation of Fundamentals**
* Dedicated session to reinforce concepts from Day 1 and Day 2.
* Fine-tuned the practical implementation of **C# Operators** (Arithmetic, Relational, Logical, and Bitwise).
* Reviewed and debugged the initial 10 basic programs to ensure coding standards and best practices (proper naming conventions and indentation) were met.


2. **Resource Review & Theory**
* Conducted an in-depth study of technical documentation and PDFs provided via **Google Classroom**.
* Focused on the internal workings of the **Common Language Runtime (CLR)**.
* Studied memory management: **Value Types** (stored on the Stack) vs. **Reference Types** (stored on the Heap).



---

### Date: December 22, 2025 | Day: 4

#### Topics Covered:

1. **Control Flow Statements**
* Explored how to control program execution paths using:
* **Selection Statements:** `if`, `else if`, `else`, and `switch` cases.
* **Iteration Statements (Loops):** `for`, `while`, and `do-while`.
* **Jump Statements:** `break`, `continue`, and `return`.





#### Practical Tasks:

* Worked on a comprehensive set of **30+ Logic Building Problems** categorized into three difficulty tiers:
* **Level 1 (Basic):** Simple conditional checks (Even/Odd, Leap Year, Voting eligibility).
* **Level 2 (Intermediate):** Loops and series (Fibonacci, Prime numbers, Factorials, Palindrome checks).
* **Level 3 (Advanced):** Complex nested logic, and mathematical sequences.



**Key Learnings:**

* Improved algorithmic thinking by breaking down complex problems into smaller, logical steps.
* Gained clarity on when to use `switch` statements over nested `if-else` for cleaner, more readable code.

---

### Date: December 23, 2025 | Day: 5

#### Topics Covered:

1. **Arrays in C#**
* Learned to store multiple values of the same type in a single indexed variable.
* Covered **Single-dimensional arrays**: declaration, initialization, and memory representation.
* Practiced iteration techniques: Using `foreach` for read-only access vs. `for` loops for index-based manipulation.

* Focused on handling **Edge Cases** (e.g., negative inputs, zero values) to ensure program stability.



#### Practical Tasks:

* Completed the remaining advanced problems from the Control Flow assignment.
* Developed 20 programs focused specifically on **Array Manipulation** (finding Max/Min values, reversing an array, and element searching).

**Key Learnings (Week 1 Summary):**

* Successfully transitioned from basic syntax to complex logic building.
* Developed a systematic workflow for tackling multi-level programming challenges.
* Gained a deeper understanding of how data structures like **Arrays** interact with **Control Flow** to solve enterprise-level scenarios.


---

### Date: December 24, 2025 | Day: 6

#### Topics Covered:
1. **Methods in C#**
   - Understanding the structure: Access modifiers, return types, and parameters.
   - Exploring the DRY (Don't Repeat Yourself) principle through encapsulation.
   - **Static vs. Instance methods**: Differences in memory and invocation.
   - **Parameter Passing**: Deep dive into `ref`, `out`, and `params` keywords.

#### Practical Tasks:
- Completed **30+ questions** focusing on method implementation.
- Modularized previous logic-building tasks into reusable methods to improve code readability.

---

### Date: December 26, 2025 | Day: 7

#### Topics Covered:
1. **Strings in C#**
   - Deep dive into String immutability and memory allocation.
   - Hands-on with string methods: `Split()`, `Substring()`, `Replace()`, and `StringBuilder` for performance optimization.
2. **Modular Game Design Logic**
   - Discussed the implementation of a **Snake and Ladders Game**.
   - **Scenario Details:**
     - Supports **2 to 4 players**.
     - Requirement to make the game **modular** using methods.
     - Implementation of methods like `RollDice()`, `MovePlayer()`, and `CheckForSnakeOrLadder()`.

#### Practical Tasks:
- Solved **20+ problems** based on String manipulation.
- **Project Work:** Developed the base structure for the Snake and Ladders game using modular methods to handle game state and player movement.

**Key Learnings:**
- Improved ability to design applications from a modular perspective.
- Mastered string handling which is crucial for data processing.

---

### Date: December 29, 2025 | Day: 8

#### Topics Covered:
1. **Introduction to OOP (Object-Oriented Programming)**
   - Transitioned from procedural logic to Object-Oriented paradigms.
   - **Procedural vs. Object-Oriented Programming:**
     - **Procedural:** Focuses on functions and sequences of actions (top-down approach).
     - **OOP:** Focuses on "objects" that contain both data (fields) and behavior (methods), promoting better organization and reusability.
   - **Classes and Objects:**
     - Understanding a **Class** as a blueprint or template.
     - Understanding an **Object** as a real-world entity or instance of that blueprint.

#### Practical Tasks:
- Focused on advanced **String Manipulation** and **Multi-dimensional Arrays** to reinforce logic-building without relying heavily on built-in .NET functions.

  **Programs:**
  1. **Strings – Sentence Formatter:**
     - Developed a method to auto-correct paragraph formatting.
     - Implemented logic to ensure exactly one space follows punctuation and capitalization after period/question/exclamation marks.
     - Handled trimming of extra spaces.

  2. **Text Analyzer Program:**
     - Implemented manual word counting and identification of the longest word.
     - Created a case-insensitive word replacement feature.
     - Added robust handling for empty strings or whitespace-only paragraphs.

  3. **Arrays – Temperature Analyzer:**
     - Worked with a **2D array (float[7][24])** to analyze hourly temperature data for a week.
     - Implemented logic to find the hottest and coldest days.
     - Calculated the average temperature for each specific day.

  4. **Student Score Management:**
     - Program to store and process scores for *n* students.
     - Calculated average scores and identified the highest/lowest marks.
     - Filtered and displayed scores that performed above the average.
     - Implemented validation for invalid inputs like negative scores or non-numeric data.

**Key Learnings:**
- Deepened understanding of manual memory/index handling in Strings by avoiding built-in shortcuts.
- Gained experience navigating and processing data within **multi-dimensional arrays**.
- Visualized the shift from writing scripts to designing systems using Classes and Objects.
- Practiced implementing complex business logic through custom algorithms.

---

### Date: December 30, 2025 | Day: 9

#### Topics Covered:
1. **C# Constructors**
   - Learned how to use constructors to initialize object state at the time of creation.
   - Explored default vs. parameterized constructors.
2. **Instance vs. Class Variables**
   - **Instance Variables:** Variables tied to a specific object (unique to each instance).
   - **Class Variables (static):** Variables shared across all instances of a class, stored in a single memory location.
3. **Access Modifiers (Level 1)**
   - Focused on the practical application of `public` and `private` for encapsulation.
   - Understanding how to protect internal data using private fields and providing controlled access.

#### Practical Tasks:
- Implemented real-world scenarios to apply constructor logic and object-oriented data management.

  **Programs:**
  1. **EduQuiz – Student Quiz Grader:**
     - Developed a grading module using two `String[]` arrays: `correctAnswers[]` and `studentAnswers[]`.
     - Implemented `CalculateScore(string[] correct, string[] student)` to process results.
     - Used case-insensitive string comparison to ensure fair grading.
     - Added a feedback loop to print "Correct/Incorrect" for each question.
     - **Bonus Feature:** Included a percentage calculation and a final Pass/Fail status message.

  2. **Library Management System (Book Search & Checkout):**
     - Designed a system to manage book details including **Title**, **Author**, and **Status** (Available/Checked Out).
     - Used arrays to store and manage multiple book objects.
     - Implemented **Partial Title Search** using string operations to help users find books easily.
     - Created modular methods for:
       - `SearchBook()`: Locating books by title.
       - `DisplayBooks()`: Listing all library inventory.
       - `UpdateStatus()`: Handling the checkout and return logic.

**Key Learnings:**
- Mastered the use of **Constructors** to ensure objects are always in a valid state upon creation.
- Gained clarity on memory allocation differences between **Static** and **Instance** members.
- Improved ability to manage collections of objects using arrays and custom search methods.

---
### Date: December 31, 2025 | Day: 10

#### Topics Covered:
1. **Keyword Specialization**
   - **`this` Keyword:** Used to refer to the current instance of the class and distinguish between class fields and parameters.
   - **`static` Keyword:** Applied to methods and fields to make them belong to the class itself rather than a specific object.
   - **`sealed` Keyword:** Learned how to prevent class inheritance to secure the design and improve performance.
   - **`is` Operator:** Used for type-checking to verify if an object is compatible with a specific type during runtime.

#### Practical Tasks:
- Completed a series of scenario-based assignments to integrate OOP keywords with complex logic.

  **Programs:**
  1. **Bank Account Manager:**
     - Designed a `BankAccount` class using `AccountNumber` and `Balance` fields.
     - Implemented `Deposit()`, `Withdraw()`, and `CheckBalance()` methods.
     - **Overdraft Protection:** Added logical checks to prevent withdrawals that exceed the current balance.

  2. **Mathematical Utility Class:**
     - Created a robust utility class containing specialized static methods:
       - **Factorial:** Iterative/Recursive logic for factorials.
       - **Prime Check:** Logic to determine primality.
       - **GCD:** Implementing the Euclidean algorithm for the Greatest Common Divisor.
       - **Fibonacci:** Finding the nth number in the sequence.
     - **Edge Case Testing:** Validated all methods against zero, one, and negative integers.

  3. **Invoice Generator for Freelancers:**
     - Developed a tool to parse raw billing strings (e.g., "Logo Design - 3000 INR").
     - **String Parsing:** Used `Split()` and string manipulation to isolate task names from currency values.
     - **Total Calculation:** Implemented `GetTotalAmount()` to aggregate the values into a final invoice sum.

**Key Learnings:**
- Understand when to use **Static** classes for utility functions vs. **Instance** classes for stateful data like Bank Accounts.
- Mastered string parsing techniques to transform unstructured user input into calculable data.
- Explored the security benefits of using the **Sealed** keyword in class architecture.

---

### Date: January 1, 2026 | Day: 11

#### Topics Covered:
1. **Object-Oriented Design (OOD) Principles**
   - Shifted focus from coding to system architecture and visualization.
   - **Class Diagrams:** Learned to represent the static structure of a system, including classes, attributes, methods, and their relationships.
   - **Object Diagrams:** Explored how to model snapshots of instances in a system at a specific point in time to verify class designs.
   - **Sequence Diagrams:** Studied how to visualize the interaction between objects over time, focusing on the order of messages exchanged to complete a task.

#### Practical Tasks:
- Developed a menu-driven application focusing on array indexing and modular method design.

  **Programs:**
  1. **Cafeteria Menu App:**
     - Built a system to manage a fixed daily menu of 10 items for a campus cafeteria.
     - **Data Storage:** Utilized a `string[]` array to maintain the list of available food items.
     - **User Interaction:** Implemented a system where the menu is printed with corresponding index numbers for easy selection.
     - **Modular Implementation:**
       - `DisplayMenu()`: Iterates through the array to show the daily offerings.
       - `GetItemByIndex()`: Retrieves and validates the user's food choice based on their numerical input.

**Key Learnings:**
- Gained the ability to "blueprint" an application using **UML diagrams** before writing a single line of code.
- Understood the importance of separating data display logic from data retrieval logic.
- Practiced defensive programming by ensuring user-selected indices are within the bounds of the menu array.

---
### Date: January 2, 2026 | Day: 12

#### Topics Covered:
1. **Inheritance in C#**
   - Explored the mechanism where a derived class acquires the properties and behaviors of a base class.
   - **Types of Inheritance:**
     - **Single Level:** One class inheriting from a single base class.
     - **Multilevel:** A derived class acting as a base class for another class.
     - **Hierarchical:** Multiple classes inheriting from one single base class.
   - **Key Features:** Code reusability, specialized behavior, and simplified maintenance.
2. **Method Overriding & Polymorphism**
   - Used the `virtual` and `override` keywords to allow derived classes to provide specific implementations of methods defined in base classes.
   - Studied how **Polymorphism** allows a base class reference to point to a derived class object.
3. **Inheritance Mechanics**
   - **Constructor Inheritance:** Understanding how base class constructors are called using the `base` keyword.
   - **Access Modifiers:** Analyzing how `protected` and `internal` modifiers affect visibility within the inheritance chain.

#### Practical Tasks:
- Applied control flow and loop logic to real-world simulation scenarios.

  **Programs:**
  1. **Bus Route Distance Tracker 🚌:**
     - Developed a tracker where each stop adds to a cumulative distance.
     - Implemented a `while` loop to continuously prompt the passenger until they choose to exit/get off.
     - Used a total distance accumulator to summarize the journey upon exit confirmation.

  2. **Festival Lucky Draw 🎉:**
     - Simulated a Diwali Mela draw system for multiple visitors using loops.
     - **Winning Logic:** Implemented conditions using the modulus operator (`%`) to check if a number is divisible by both 3 and 5.
     - **Validation:** Utilized the `continue` statement to skip processing and re-prompt if an invalid draw number is entered.

**Key Learnings:**
- Mastered the ability to create class hierarchies to reduce redundancy in large systems.
- Understood the power of **Method Overriding** in creating flexible and extensible code.
- Practiced combining complex loop structures (`while` and `continue`) with business-specific winning conditions.

---
### Date: January 5, 2026 | Day: 13

#### Topics Covered:
1. **Encapsulation & Data Hiding**
   - Implemented proper data protection using **Properties** (getters and setters).
   - Focused on bundling data and the methods that operate on that data within a single unit to prevent unauthorized access.
2. **Abstraction (Abstract Classes & Interfaces)**
   - **Abstract Classes:** Used as base classes that cannot be instantiated, providing a partial implementation for derived classes.
   - **Interfaces:** Defined strict contracts using the `interface` keyword to ensure different classes implement specific behaviors.
3. **Advanced Polymorphism**
   - Applied dynamic polymorphism to handle different object types through a single interface or base class reference.

#### Practical Tasks:
- Developed two comprehensive systems to integrate all four pillars of Object-Oriented Programming.

  **Programs:**
  1. **Hospital Patient Management System:**
     - **Classes:** Designed `Patient`, `Doctor`, and `Bill` classes.
     - **Encapsulation:** Used properties to manage sensitive patient and billing data.
     - **Abstraction:** Implemented an `IPayable` interface to standardize payment processing across different billing types.
     - **Inheritance:** Created `InPatient` and `OutPatient` classes inheriting from the base `Patient` class.
     - **Polymorphism:** Overrode `DisplayInfo()` to provide specific output for different patient categories.

  2. **Vehicle Rental Application:**
     - **Architecture:** Developed a hierarchy with `Vehicle` as a base for `Bike`, `Car`, and `Truck`.
     - **Access Control:** Utilized `protected` fields to allow child classes to access vehicle specifications while hiding them from the rest of the application.
     - **Interface Implementation:** Created an `IRentable` interface with a `CalculateRent(int days)` method.
     - **Logic:** Each vehicle type (Bike/Car/Truck) provided its own specific rental rate logic through the interface implementation.

**Key Learnings:**
- Mastered the distinction between **Abstraction** (what a system does) and **Encapsulation** (how it hides its internal state).
- Learned to use **Interfaces** to decouple code, making the system more flexible and easier to test.
- Gained experience in designing multi-class systems that interact through inheritance and shared interfaces.

---
### Date: January 6, 2026 | Day: 14

#### Topics Covered:
1. **Consolidation of OOP & Interface Implementation**
   - Focused on completing advanced assignments from the previous session.
   - Deepened understanding of **Multiple Interface Implementation** (how a single class can implement multiple behaviors).
   - **Polymorphism with Interfaces:** Using the `is` operator and interface casting to trigger specific behaviors (e.g., `Fly()` or `Swim()`) from a collection of mixed objects.

#### Practical Tasks:
- Implemented complex real-world logic using polymorphic collections and string filtering.

  **Programs:**
  1. **EcoWing Bird Sanctuary System:**
     - **Base Architecture:** Created a `Bird` base class for shared attributes.
     - **Behavioral Interfaces:** - `IFlyable` with a `Fly()` method.
       - `ISwimmable` with a `Swim()` method.
     - **Derived Classes:** - `Eagle` and `Sparrow` (Implemented `IFlyable`).
       - `Duck` and `Penguin` (Implemented `ISwimmable`).
       - `Seagull` (Implemented both `IFlyable` and `ISwimmable`).
     - **Polymorphism in Action:** Used an array to store all birds and iterated through them, using the `is` operator to check interface compatibility before calling the respective action methods.

  2. **Customer Service Call Log Manager:**
     - **Data Modeling:** Designed a `CallLog` class with `PhoneNumber`, `Message`, and `Timestamp`.
     - **Collection Management:** Managed an array of `CallLog` objects to simulate a telecom database.
     - **Search & Filter Logic:** - Implemented `SearchByKeyword()` using `string.Contains` to find specific messages.
       - Built `FilterByTime()` to retrieve logs within a specific time range.
       - Developed `AddCallLog()` for dynamic entry management.

**Key Learnings:**
- Mastered the ability to handle objects based on their **capabilities** (Interfaces) rather than just their **type** (Inheritance).
- Gained experience in filtering and querying object arrays using string manipulation and conditional logic.
- Understood how to model real-world wildlife and business scenarios into a clean, modular class hierarchy.

---
### Date: January 7, 2026 | Day: 15

#### Topics Covered:
1. **Introduction to Data Structures**
   - Successfully transitioned from Object-Oriented Programming to the study of memory-efficient data organization.
   - **Singly Linked List:** Understanding nodes containing data and a reference to the next node.
   - **Doubly Linked List:** Exploring nodes with two references (next and previous) allowing two-way traversal.
   - **Circular Linked List:** Learning the structure where the last node points back to the first, creating a continuous loop.
2. **Professional Git Workflow**
   - Practiced working with the Master branch for stable releases.
   - Applied basic Git flows including committing and branching for specific feature sets (Use Cases).

#### Practical Tasks:
- Initiated the **Employee Wage Computation Problem**, integrating all previously learned C# concepts into a single, scalable project.

  **Project Milestones (Use Cases):**
  - **Project Setup:** Initialized the program with a welcome message on the Master branch.
  - **UC1 (Attendance):** Used the `Random` class to simulate employee attendance (Present/Absent).
  - **UC2 (Daily Wage):** Calculated wages based on parameters (Wage per Hour = 20, Full Day = 8 hours).
  - **UC3 (Part-Time):** Added support for part-time employee logic with an 8-hour shift assumption.
  - **UC4 (Refactoring):** Implemented `switch-case` statements to handle different employee types more efficiently.
  - **UC5 (Monthly Calculation):** Added logic to compute wages for a standard working month of 20 days.
  - **UC6 (Conditional Logic):** Implemented a loop to calculate wages until a specific limit is reached (either 100 total hours or 20 total days).

**Key Learnings:**
- Developed a deep understanding of manual memory linking through **Linked Lists**.
- Learned how to structure a professional project using **Use Cases (UC)** to break down complex requirements.
- Mastered the use of static and instance variables to maintain state across an entire computation module.
- Gained experience in using **Randomization** to simulate real-world uncertainty in business logic.

---
### Date: January 8, 2026 | Day: 16

#### Topics Covered:
1. **Linear Data Structures**
   - **Stack (LIFO):** Learned the Last-In-First-Out principle using `Push()` and `Pop()` operations.
   - **Queue (FIFO):** Explored the First-In-First-Out mechanism using `Enqueue()` and `Dequeue()`.
2. **Hashing & Key-Value Pairs**
   - **Dictionary (HashMap):** Studied the implementation of unique key-value pairs for fast data retrieval ($O(1)$ average time complexity).
   - **Hash Function:** Understanding how hash functions map data of arbitrary size to fixed-size values to enable efficient indexing.

#### Practical Tasks:
- Continued reinforcing **Object-Oriented Programming (OOP)** through a specialized automation scenario.

  **Programs:**
  1. **Smart Home Automation System:**
     - **Architecture:** Created a base `Appliance` class with derived classes for `Light`, `Fan`, and `AC`.
     - **Interface Implementation:** Developed an `IControllable` interface featuring `TurnOn()` and `TurnOff()` methods.
     - **Advanced Polymorphism:** - Implemented specialized behavior for each appliance.
       - Example: Turning on a `Light` might adjust brightness/color, whereas turning on an `AC` initializes temperature settings and fan speed.
     - **Encapsulation:** Protected the internal state of each appliance (e.g., current temperature or power status) using private fields and public properties.

**Key Learnings:**
- Gained clarity on when to use a **Stack** (e.g., undo operations) versus a **Queue** (e.g., printer tasks).
- Mastered the use of **Dictionaries** for scenarios requiring high-performance data lookups.
- Refined the ability to use **Interfaces** to group different objects (Light, AC) under a common behavior (`IControllable`) while maintaining unique polymorphic implementations.

---
### Date: January 9, 2026 | Day: 17

#### Topics Covered:
1. **Sorting Algorithms (Deep Dive)**
   - Started a comprehensive study of sorting techniques to optimize data organization:
     - **Bubble Sort:** Simple comparison-based sorting by repeatedly swapping adjacent elements.
     - **Insertion Sort:** Building the final sorted array one item at a time (efficient for small datasets).
     - **Merge Sort:** A "Divide and Conquer" algorithm that splits arrays into halves, sorts them, and merges them back.
     - **Quick Sort:** High-performance sorting using a "pivot" element to partition the array.
2. **Greedy Algorithms & Logic**
   - Explored the **Optimal Change Problem** to understand how to minimize the number of units (notes) used to reach a specific target value.

#### Practical Tasks:
- Balanced advanced Object-Oriented design with complex algorithmic problem-solving.

  **Programs:**
  1. **FitTrack – Fitness Tracker:**
     - **Core Classes:** Designed `UserProfile` to manage user data and `Workout` as a base class.
     - **Interface Implementation:** Used `ITrackable` to ensure all workout types can log metrics.
     - **Specialized Workouts:** Implemented `CardioWorkout` and `StrengthWorkout`, each providing unique logic for calorie and progress tracking.

  2. **ATM Dispenser Logic (Data Structures & Optimization):**
     - **Scenario A:** Implemented logic to dispense the minimum number of notes for ₹880 using a standard currency set (₹500, ₹200, ₹100, etc.).
     - **Scenario B (Constraint Testing):** Modified the algorithm to handle the temporary removal of the ₹500 note, forcing the system to re-calculate using smaller denominations.
     - **Scenario C (Edge Cases):** Developed a fallback mechanism to display the closest possible combination if the exact change cannot be formed.

  3. **Sorting Assignment:**
     - Started work on a **7-question comprehensive assignment** focusing on implementing and comparing the efficiency (Time/Space Complexity) of Bubble, Insertion, Merge, and Quick sort.

**Key Learnings:**
- Understood the trade-offs between different sorting algorithms ($O(n^2)$ vs $O(n \log n)$).
- Gained experience in modifying algorithms on the fly to handle real-world constraints (like a missing currency note).
- Refined the use of **Interfaces** to manage different types of physical activities under a unified fitness tracking system.


---

### Date: January 9, 2026 | Day: 18

#### Topics Covered:
1. **Optimization & Greedy Logic (Rod Cutting)**
   - Explored the **Rod Cutting Problem** to understand how to maximize value by partitioning a whole into smaller pieces based on a price chart.
   - Practiced analyzing the impact of constraints (like fixed waste or custom lengths) on total revenue.
2. **C# String Handling & IO Operations**
   - **StringBuilder vs. StringBuffer:** Studied the differences in thread safety and performance for mutable strings.
   - **File IO:** Learned to read data using `FileReader` and `InputStreamReader` for handling external data sources.
3. **Search Algorithms**
   - **Linear Search:** Sequential checking of every element ($O(n)$ complexity).
   - **Binary Search:** Efficient searching in sorted arrays by repeatedly dividing the search interval in half ($O(\log n)$ complexity).

#### Practical Tasks:
- Implemented high-level business logic and algorithmic optimization scenarios.

  **Programs:**
  1. **Industrial Optimization (Metal & Wood Cutting):**
     - **Scenario A:** Developed logic to find the best cut strategy for an 8ft metal rod and a 12ft wooden rod to maximize earnings.
     - **Scenario B:** Modified logic to incorporate "Custom-length orders" and "Fixed waste constraints."
     - **Scenario C:** Created a comparison to visualize the revenue loss when using non-optimized cut strategies.

  2. **LoanBuddy – Loan Approval Automation:**
     - **Core Architecture:** Designed `Applicant` and `LoanApplication` classes.
     - **Encapsulation:** Secured `creditScore` and internal approval logic using private access modifiers to prevent external tampering.
     - **Inheritance:** Extended the base loan class into `HomeLoan` and `AutoLoan`.
     - **Interface & Math:** Implemented `IApprovable` to standardize `approveLoan()` and `calculateEMI()`.
     - **EMI Formula Implementation:** Used the standard formula: $$P \times R \times \frac{(1+R)^N}{(1+R)^N - 1}$$
     - **Polymorphism:** Customized the EMI calculation and interest rates based on the specific loan type.

  3. **Search & IO Assignment:**
     - Developed a suite of tools to demonstrate **Linear** and **Binary Search** performance.
     - Practiced reading configuration files using **InputStreamReader** to initialize program state.

**Key Learnings:**
- Mastered the ability to translate complex financial formulas into clean, encapsulated C# code.
- Gained a deep understanding of why **Binary Search** is superior for large, sorted datasets.
- Learned to handle real-world manufacturing constraints (waste management) through algorithmic adjustments.
- Understood the performance benefits of **StringBuilder** when performing heavy string concatenations in loops.

---
### Date: January 13, 2026 | Day: 19

#### Topics Covered:
1. **Dynamic Collections (List & ArrayList)**
   - Moved beyond fixed-size arrays to dynamic collections.
   - Learned the benefits of `List<T>` for type safety and `ArrayList` for flexible data storage.
   - Practiced converting collections to arrays using `.ToArray()` for report generation and exports.
2. **Exception Handling & Custom Exceptions**
   - **Try-Catch-Finally:** Learned to handle runtime errors gracefully without crashing the application.
   - **Custom Exceptions:** Practiced throwing specific exceptions (e.g., `InvalidTimeFormatException`) to enforce business rules.
   - **Built-in Exceptions:** Handled common errors like `IndexOutOfBoundsException` and null checks.
3. **Algorithm Analysis & Best Practices**
   - **Big O Notation:** Introduced to Time and Space Complexity analysis.
   - **Optimization:** Discussed best practices for writing clean, efficient code by reducing redundant loops and memory allocations.

#### Practical Tasks:
- Developed user-centric applications focusing on data management and robust error handling.

  **Programs:**
  1. **CinemaTime – Movie Schedule Manager:**
     - **Data Management:** Used separate `List<string>` collections for movie titles and showtimes.
     - **Functionalities:**
       - `AddMovie()`: Appends new titles and times.
       - `SearchMovie()`: Implemented keyword search using `string.Contains`.
       - `DisplayAllMovies()`: Formatted output using string concatenation and `.format()`.
     - **Exception Handling:** - Handled `IndexOutOfBoundsException` for search errors.
       - Created logic to throw an `InvalidTimeFormatException` for impossible times like "25:99".

  2. **BookBuddy – Digital Bookshelf App:**
     - **Storage:** Used an `ArrayList` to store books in a specific "Title - Author" format.
     - **Logic:**
       - `SortBooksAlphabetically()`: Used collection sorting algorithms to organize the shelf.
       - `SearchByAuthor()`: Leveraged `string.Split()` to isolate and verify the author name within the formatted string.
     - **Error Resilience:**
       - Implemented `try-catch` blocks to manage empty list scenarios.
       - Enforced a strict input format via a custom `InvalidBookFormatException`.

  3. **Complexity & Optimization Assignment:**
     - Conducted a review of previous logic-building tasks to identify areas where time complexity could be improved from $O(n^2)$ to $O(n \log n)$ or $O(n)$.

**Key Learnings:**
- Mastered the transition from **Static Arrays** to **Dynamic Lists**, allowing for more flexible data input.
- Understood that **Exception Handling** is not just for errors, but for enforcing domain-specific rules (like valid time formats).
- Learned to evaluate code not just by "if it works," but by its **Efficiency and Scalability** using Big O analysis.

---
### Date: January 14, 2026 | Day: 20

#### Topics Covered:
1. **Manual Data Management (Arrays & Strings Only)**
   - Focused on building a complex system without the Collection Framework to master low-level data handling.
   - **Array Manipulation:** Implementing CRUD (Create, Read, Update, Delete) operations using fixed-size arrays and manual indexing.
   - **String Logic:** Using string comparison and formatting to manage contact details and search functionality.
2. **System Architecture & Professional Standards**
   - **Code Hygiene:** Strict adherence to naming conventions and indentation to ensure maintainability.
   - **Branching Strategy:** Managed a professional Git workflow by creating separate branches for each of the 11 Use Cases (UC) and merging them into the Master branch.
   - **Object-Oriented Mapping:** Establishing relationships between the `AddressBookMain`, `AddressBook`, and `Contact` classes using only custom objects and array storage.

#### Practical Tasks:
- Initiated the **AddressBook System**, building the core engine through 11 progressive Use Cases using pure C# arrays and string operations.

  **Project Milestones (Use Cases 1 - 11):**
  - **UC 1-2 (Initialization):** Created the `Contact` class (Name, Address, Zip, etc.) and implemented manual array storage for entries.
  - **UC 3-4 (CRUD Operations):** Developed algorithms to **Edit** and **Delete** contacts by searching through array indices and shifting elements to maintain data integrity.
  - **UC 5-6 (Multi-Management):** Expanded the system to support multiple persons and multiple named Address Books using array-based "dictionaries" (manual key-value mapping).
  - **UC 7 (Duplicate Prevention):** Implemented a manual loop to check for duplicate names before adding a new contact.
  - **UC 8-10 (Search & Analytics):**
    - Built search logic to filter and display persons across different cities or states by iterating through the arrays.
    - Implemented manual **Count** logic to aggregate contacts by location.
  - **UC 11 (Sorting):** Developed a manual sorting algorithm (e.g., Bubble Sort) to organize address book entries alphabetically by name.

**Key Learnings:**
- Deepened understanding of **Memory Management** by handling data limits and array resizing manually.
- Mastered the **CRUD pattern** from a fundamental level, ensuring a strong foundation before moving to automated collections.
- Learned the importance of **Git Version History** and modular development in a project-based environment.
- Gained experience in overriding `Equals()` and `ToString()` to customize object interaction within manual arrays.

---
### Date: January 15, 2026 | Day: 21

#### Topics Covered:
1. **Hybrid Data Structures**
   - Explored the combination of multiple data structures to solve complex, real-world state management problems.
   - **Doubly Linked List in Action:** Used for linear navigation (Back/Forward) where each node represents a visited URL with pointers to both the previous and next pages.
   - **Stack for Session Recovery:** Implemented a "Last-In-First-Out" (LIFO) stack to store closed tabs, allowing users to restore their most recently closed session.
2. **Pointer-Based Memory Management**
   - Focused on memory efficiency by using references (pointers) to navigate history rather than duplicating data.
   - Studied the mechanics of updating `head`, `tail`, and `current` pointers during tab transitions.

#### Practical Tasks:
- Developed **BrowserBuddy**, a tab history manager simulating modern browser navigation logic.

  **Programs:**
  1. **BrowserBuddy – Tab History Manager:**
     - **Navigation Logic:** Implemented a Doubly Linked List to support seamless "Forward" and "Backward" operations.
     - **Undo/Restore Feature:** Integrated a **Stack** to hold `Tab` objects upon closure.
     - **Methods Implemented:**
       - `VisitPage(string url)`: Adds a new node to the history and clears the "forward" stack.
       - `GoBack()` / `GoForward()`: Moves the current pointer across the Doubly Linked List.
       - `CloseTab()`: Pushes the current tab state onto the "Closed Tabs" stack.
       - `RestoreTab()`: Pops the last closed tab from the stack and reintegrates it into the active session.

**Key Learnings:**
- Mastered the practical difference between **linear navigation** (Linked Lists) and **temporal storage** (Stacks).
- Gained experience in managing "state" in an application—understanding how to keep track of where a user is and where they have been.
- Improved ability to design memory-efficient systems by manipulating pointers instead of rebuilding collections during navigation.

---

### Date: January 16, 2026 | Day: 22

#### Topics Covered:
1. **Custom Data Structure Implementation (No Collections Framework)**
   - **Circular Linked List (CLL):** Built a manual CLL where the tail node points back to the head, simulating a continuous loop for resource scheduling.
   - **Custom Queue:** Implemented a fixed-size array-based Queue with manual `front` and `rear` pointer management to handle overflow and underflow.
   - **Custom HashMap/Dictionary:** Designed a manual hashing system using an array of custom Linked Lists (Chaining) to handle collisions and map keys to values.
2. **Hybrid System Design**
   - Focused on "Chaining" logic: where an array index (Genre) points to the head of a custom Linked List (Books).

#### Practical Tasks:
- Developed two advanced simulation systems using strictly custom-built data structures, OOP principles, and Core C#.

  **Programs:**
  1. **TrafficManager – Roundabout Vehicle Flow:**
     - **Circular Path:** Represented a roundabout using a **Custom Circular Linked List**, where vehicles can enter and exit dynamically without a "dead end."
     - **Waiting Logic:** Implemented a **Manual Queue** to manage vehicles waiting to enter the roundabout.
     - **Functionalities:** - Added/Removed vehicle nodes.
       - Handled **Queue Overflow** (when the entry road is full) and **Underflow** (when no vehicles are waiting).
       - Method to traverse the circular list to print the real-time state of the roundabout.

  2. **BookShelf – Library Organizer:**
     - **Custom Catalog:** Built a **Custom HashMap** mapping `Genre` (String) to a `Custom Linked List` of books.
     - **Logic:** - Used a custom hash function to determine the array index for each genre.
       - Each bucket in the array holds a Linked List to handle multiple books within the same genre (Collision Handling).
     - **Operations:**
       - Efficient insertion and deletion of books when borrowed or returned.
       - Implemented manual loops to ensure no duplicate books exist within a specific genre list.

**Key Learnings:**
- Mastered **Collision Handling** in HashMaps by manually implementing "Chaining" with Linked Lists.
- Understood the power of **Circular Data Structures** for modeling real-world loops like traffic flow.
- Gained deep insight into **Memory Management** by manually linking nodes and managing array bounds without the safety net of the .NET Collection Library.
- Refined the ability to combine multiple custom structures (Queue + CLL) to solve multi-stage problems.

---

### Date: January 17, 2026 | Day: 23

#### Topics Covered:
1. **Algorithmic Efficiency & Selection**
   - **Divide and Conquer (Quick Sort):** Studied the recursive partitioning strategy. Learned why choosing a "pivot" is critical for achieving an average-case time complexity of $O(n \log n)$ when handling millions of records.
   - **Brute Force Optimization (Bubble Sort):** Analyzed the $O(n^2)$ complexity. Understood that for small, nearly-sorted datasets (like real-time leaderboards), the simplicity and low overhead of Bubble Sort can be advantageous.
2. **Manual Memory Swapping**
   - Implemented manual `Swap()` logic to reorder elements within fixed arrays without using temporary lists or built-in sort methods.

#### Practical Tasks:
- Implemented two distinct sorting engines tailored for specific e-commerce and fitness industry scenarios.

  **Programs:**
  1. **FlashDealz – Product Sorting by Discount:**
     - **Scenario:** Processing a flash sale with a massive dataset of product discounts.
     - **Implementation:** Built a **Custom Quick Sort** algorithm.
     - **Logic:** - Partitioned the product array based on a pivot discount value.
       - Recursively sorted the high-discount and low-discount subarrays to bring the "Top Deals" to the front.
     - **Performance:** Optimized for large-scale data where manual iteration would be too slow.

  2. **FitnessTracker – Daily Step Count Ranking:**
     - **Scenario:** Managing a leaderboard for a small group (under 20 users) with frequent real-time updates.
     - **Implementation:** Built a **Custom Bubble Sort**.
     - **Logic:** - Performed adjacent comparisons of step counts, "bubbling" the highest counts to the top of the array.
       - Optimized with a `swapped` flag to terminate the pass early if the list is already sorted, making it efficient for last-minute step syncing.
     - **Context:** Leveraged the algorithm's stability to handle frequent re-sorting as new data points arrive.

**Key Learnings:**
- Mastered the **Pivot and Partition** logic, which is the backbone of high-performance sorting.
- Understood the trade-off between **Algorithm Complexity** and **Data Size**: Quick Sort for millions of products vs. Bubble Sort for a small group of friends.
- Gained hands-on experience in **Recursive Programming** and managing the call stack manually during Quick Sort execution.
- Refined the ability to implement real-time data re-sorting using only core C# arrays.

---
### Date: January 19, 2026 | Day: 24

#### Topics Covered:
1. **C# Generics**
   - Introduced the concept of type parameters (`<T>`) to create highly reusable classes and methods.
   - **Benefits:** Learned how Generics provide type safety without the overhead of boxing/unboxing, while eliminating the need for duplicate code for different data types.
   - **Generic Constraints:** Explored how to restrict generic types to specific interfaces or base classes.
2. **Advanced System Design with Custom DSA**
   - **Singly Linked List (SLL):** Used for linear state-machine transitions (tracking progress).
   - **Stack & Hashing Integration:** Combined LIFO navigation with a manual Key-Value storage system to handle real-time data input and retrieval.

#### Practical Tasks:
- Implemented a suite of generic-based solutions and two comprehensive simulation systems using custom-built logic.

  **Programs:**
  1. **ParcelTracker – Delivery Chain Management:**
     - **Architecture:** Used a **Custom Singly Linked List** to represent the lifecycle of a parcel (Packed → Shipped → In Transit → Delivered).
     - **Dynamic Routing:** Implemented logic to add custom intermediate checkpoints between existing nodes.
     - **Fault Tolerance:** Developed rigorous handling for "lost parcels" by managing null pointers and ensuring the chain doesn't break during traversal.

  2. **ExamProctor – Online Exam Review System:**
     - **Navigation Logic:** Used a **Manual Stack** to track the last-visited questions, enabling a "Back" feature for students.
     - **Answer Storage:** Implemented a **Custom HashMap** (Genre-to-List style chaining) to map `QuestionID` to `Answer`.
     - **Evaluation Engine:** Created specialized functions to iterate through the HashMap and auto-calculate the final score based on stored answers versus a key.

  3. **Generics Assignment:**
     - Completed a **5-question implementation task** focusing on:
       - Creating a Generic `Box<T>` to store any data type.
       - Implementing a Generic `Swap<T>` method.
       - Designing a Generic `List` equivalent from scratch to handle various object types (int, string, custom objects).

**Key Learnings:**
- Mastered the ability to write **Type-Safe** code using Generics, significantly reducing code redundancy.
- Gained experience in modeling **Process Flows** using Singly Linked Lists, focusing on sequential state transitions.
- Understood how to combine a **Stack** (for navigation) and a **HashMap** (for data lookup) to build a multi-functional application like a Proctoring system.
- Refined pointer management when handling missing data (null pointers) in custom-built chains.

---

### Date: January 20, 2026 | Day: 25

#### Topics Covered:
1. **Non-Comparison Sorting (Radix Sort)**
   - Studied **Radix Sort** to handle large numerical datasets (like 12-digit Aadhar numbers).
   - Learned how to sort digit-by-digit (from Least Significant Digit to Most Significant Digit) to achieve linear time complexity $O(nk)$ for fixed-length keys.
   - **Stability:** Focused on maintaining the relative order of records with identical prefixes.
2. **Backtracking Algorithms**
   - Explored the "Trial and Error" nature of Backtracking to find solutions by exploring all possibilities and abandoning paths that fail.
   - Applied recursive logic to build strings and states dynamically.
3. **Introduction to Collections Framework**
   - Began the official assignment on the **C# System.Collections** and **System.Collections.Generic** namespaces.
   - Transitioning from manual array management to built-in types like `List<T>`, `Dictionary<K,V>`, and `HashSet<T>`.

#### Practical Tasks:
- Implemented high-security and optimization scenarios using manual arrays and custom-built logic.

  **Programs:**
  1. **Aadhar Number Processor:**
     - **Scenario A (Radix Sort):** Implemented a manual Radix Sort to organize 12-digit numbers. Since 12-digit numbers exceed `int` capacity, logic was handled using `long` or string-index mapping.
     - **Scenario B (Search):** Developed a **Binary Search** algorithm to perform high-speed lookups in the $O(\log n)$ sorted dataset.
     - **Scenario C (Stability):** Ensured the sorting logic preserved the original entry order for matching prefixes, verifying the "Stable Sort" property.

  2. **Vault Password Cracker Simulator:**
     - **Backtracking Logic:** Built a recursive engine to generate all possible alphanumeric combinations of length $n$.
     - **State Termination:** Implemented an early-exit condition to stop the recursion immediately once the target password is matched.
     - **Complexity Analysis:** Manually calculated the exponential time complexity $O(k^n)$—where $k$ is the character set and $n$ is length—to visualize the physical limits of brute-force cracking.

**Key Learnings:**
- Understood that **Radix Sort** is significantly faster than Quick Sort for specific data types like ID numbers or Zip codes.
- Mastered the **Recursive Backtracking** pattern, which is essential for solving puzzles, pathfinding, and optimization problems.
- Successfully managed the transition from **manual data structures** to the **Collections Framework**, appreciating the internal complexity of the libraries now that I have built them from scratch.

---

### Date: January 21, 2026 | Day: 26

#### Topics Covered:
1. **Divide and Conquer (Merge Sort)**
   - Studied the efficiency of $O(n \log n)$ sorting.
   - **Stability in Sorting:** Focused on how Merge Sort preserves the relative order of items with equal values (critical for student ranking systems).
   - **Merging Logic:** Mastered the process of taking two pre-sorted sub-lists and combining them into a single sorted list efficiently.
2. **C# Streams & Data Handling**
   - **Stream Processing:** Learned to read and write data as a continuous flow of bytes or characters.
   - **File Streams:** Practiced handling large datasets that are too big for memory by using `FileStream` and `StreamReader/StreamWriter`.
3. **Advanced System Interaction**
   - Practiced combining **FIFO (Queues)** for flow control with **HashMaps** for instant data lookup.

#### Practical Tasks:
- Built high-capacity simulation tools using custom algorithms and stream-based data handling.

  **Programs:**
  1. **EduResults – Rank Sheet Generator:**
     - **Scenario:** Merging district-wise student results into a single state-wide leaderboard.
     - **Implementation:** Built a **Custom Merge Sort** engine.
     - **Logic:** - Implemented the recursive "Divide" phase to break down the thousands of records.
       - Built a robust "Merge" function that takes two sorted district arrays and combines them while maintaining stability for students with identical scores.
     - **Scalability:** Designed to handle large datasets where stability and performance are equally prioritized.

  2. **SmartCheckout – Supermarket Billing System:**
     - **Queue Management:** Implemented a **Custom Queue** for each checkout counter to manage customer flow (First-In, First-Out).
     - **Pricing Engine:** Used a **Custom HashMap** (Genre-to-List style) where `ItemName` acts as the key to fetch `Price` and `StockCount` in $O(1)$ time.
     - **Transaction Logic:** - Programmatically decremented stock levels upon successful purchase.
       - Handled "Out of Stock" scenarios during the checkout process.
       - Calculated the final bill by iterating through the customer's item list and fetching values from the Map.

**Key Learnings:**
- Understood why **Merge Sort** is the industry standard for external sorting and merging pre-sorted data.
- Mastered the interaction between different data structures: using a **Queue** to manage people and a **HashMap** to manage inventory data simultaneously.
- Gained experience in **Stream Processing**, understanding how to handle data inputs that might come from external district files.
- Refined manual memory logic by ensuring that pointers and array indices are perfectly synchronized during complex merge operations.

---
### Date: January 22, 2026 | Day: 27

#### Topics Covered:
1. **Advanced Exception Handling**
   - Deepened understanding of the `try-catch-finally` block for mission-critical systems.
   - **Propagating Exceptions:** Learned how to throw and re-throw exceptions when a required resource (like an available hospital bed) is not found.
   - **Custom Error States:** Practiced defining specific error scenarios, such as `UnitUnderMaintenanceException` or `NoAvailableUnitException`.
2. **Circular Resource Allocation**
   - Focused on the **Circular Linked List (CLL)** as a model for systems that have no defined end-point and require continuous polling.

#### Practical Tasks:
- Developed a high-stakes medical navigation simulation using custom-built CLL and robust error handling.

  **Programs:**
  1. **AmbulanceRoute – Emergency Patient Navigation:**
     - **Circular Unit Mapping:** Created a manual CLL representing the hospital loop: **Emergency → Radiology → Surgery → ICU → Emergency**.
     - **Search & Rotation Logic:** - Implemented a rotation algorithm that starts from the entry point and traverses the circular path to find the first node marked as "Available."
       - Ensured the logic handles the scenario where the search returns to the starting node (all units full).
     - **Maintenance Management:** - Developed a method to "Remove" a node (Building/Unit) from the circular chain if it is flagged for maintenance, carefully reconnecting the `next` pointers to maintain the loop's integrity.
       - Integrated **Exception Handling** to catch errors if an ambulance attempts to route a patient to a unit that was just taken offline.
     - **Redirection Simulation:** Used logic to redirect patients in a continuous circular path until a "Success" state is reached or an exception is thrown.

**Key Learnings:**
- Mastered the **"Next-Fit" allocation logic** by using a Circular Linked List to find the nearest available resource.
- Learned to handle **Pointer Reassignment** in a circular structure, which is significantly more complex than a standard list because the tail must always point back to the head.
- Understood the critical role of **Exception Handling** in real-time systems; for an ambulance, an unhandled exception or a broken link in the data could simulate a system failure.
- Reinforced the **No Collection Framework** constraint by manually managing node references and building state-check loops.

---

### Date: January 23, 2026 | Day: 28

#### Topics Covered:
1. **Automated Testing with MSTest**
   - Learned the fundamentals of Unit Testing to ensure code reliability.
   - Practiced writing test methods with `[TestMethod]` and `[TestClass]` attributes.
   - Focused on **Assertions** (`Assert.AreEqual`, `Assert.IsTrue`) to validate that custom DSA logic behaves as expected under edge cases.
2. **Regular Expressions (Regex)**
   - Studied pattern matching for data validation.
   - Mastered the use of quantifiers, character classes, and anchors to validate complex strings like Email IDs, Phone Numbers (from the AddressBook project), and Aadhar numbers.
3. **Annotations & Reflection**
   - **Annotations:** Used metadata attributes to provide instructions to the compiler and runtime.
   - **Reflection:** Explored the power of inspecting and interacting with object types at runtime. Learned how to dynamically access methods, properties, and constructors even if they are private.
4. **Static Code Analysis (SonarQube)**
   - Introduced **SonarQube** for automated code reviews.
   - Focused on detecting "Code Smells," security vulnerabilities, and bugs in existing projects like the AddressBook or LoanBuddy systems.

#### Practical Tasks:
- Integrated testing and validation frameworks into previously built custom systems.

  **Implementation Highlights:**
  1. **AddressBook Validation (Regex):**
     - Refactored the manual AddressBook system to include **Regex-based validation** for all inputs (ensuring Zip codes are numeric and names start with capital letters).
  
  2. **Unit Testing Custom DSA:**
     - Wrote **MSTest suites** for the manual Linked Lists and Queues to verify that `Push`, `Pop`, `Enqueue`, and `Dequeue` operations don't cause index errors or null pointer exceptions.

  3. **SonarQube Integration:**
     - Ran a local SonarQube scan on a project to analyze **Cyclomatic Complexity** and identify redundant loops or unused variables.
     - Practiced fixing "Code Smells" identified by the tool to improve overall code hygiene.

  4. **Reflection Utility:**
     - Created a small utility that uses Reflection to list all methods of a class at runtime, helping understand how frameworks like MSTest identify test methods automatically.

**Key Learnings:**
- Understood that **Testing** is as important as **Development** in a professional environment.
- Learned how **Regex** significantly simplifies complex string validation compared to manual `if-else` loops.
- Realized the power of **Reflection** in building flexible systems that can adapt to different classes without hard-coding.
- Gained exposure to **SonarQube**, shifting the mindset from "it works" to "it is high-quality, maintainable code."

---

### Date: January 27, 2026 | Day: 29

#### Topics Covered:
1. **Custom Metadata Design (Annotations)**
   - Learned how to define and apply custom **Attributes** (Annotations) to classes and methods to provide "markers" for system behavior.
   - Practiced using `[AttributeUsage]` to control where metadata can be applied (e.g., only on methods or only on classes).
2. **Runtime Metadata Discovery (Reflection)**
   - Developed logic to scan assemblies at runtime, effectively "reading" the code's own structure.
   - Used `GetMethods()`, `GetCustomAttributes()`, and `PropertyInfo` to extract metadata without knowing the class structure in advance.
3. **Structured Data Generation (JSON)**
   - Transitioned from simple console output to **JSON serialization**, ensuring that logs and documentation are in a machine-readable format.

#### Practical Tasks:
- Implemented two professional-grade system utilities designed to automate documentation and security auditing.

  **Programs:**
  1. **HealthCheckPro – API Metadata Validator:**
     - **Goal:** Automate API documentation for hospital lab test systems.
     - **Implementation:**
       - Defined custom attributes: `[PublicAPI]` and `[RequiresAuth]`.
       - Built a scanner that iterates through "Controller" classes using **Reflection**.
       - Logic: If a method lacks a specific tag, it is flagged. If present, the tool extracts the method name and tag to auto-generate a summary report.
  
  2. **EventTracker – Auto Audit System:**
     - **Goal:** Create an automated security log for user actions (Login, Delete, etc.).
     - **Implementation:**
       - Created the `[AuditTrail]` attribute to mark sensitive methods.
       - The scanner identifies these marked methods and triggers a logging mechanism whenever they are referenced.
       - **Output:** Generated structured **JSON logs** containing the Method Name, Timestamp, and Metadata, providing a professional audit trail for enterprise security.

**Key Learnings:**
- Realized the power of **"Code that writes code"**—using Reflection to automate boring tasks like documentation.
- Understood how modern frameworks (like ASP.NET or Spring) use annotations to handle security and routing under the hood.
- Mastered the ability to turn runtime objects into structured **JSON strings** for external system integration.
- Successfully caught up on pending assignments, ensuring a solid foundation in Regex and MSTest before moving further into system architecture.

---

### Date: January 28, 2026 | Day: 30

#### Topics Covered:
1. **File I/O: CSV Data Handling**
   - Learned to parse and manipulate **Comma Separated Values (CSV)** files manually.
   - Practiced reading data streams, splitting strings by delimiters, and mapping raw text into structured objects.
2. **Advanced Exception Handling & Business Logic**
   - Developed custom exception classes (`InvalidFlightException`) to handle industry-specific constraints.
   - Applied **Regex** within a business context to validate strict patterns like "FL-XXXX".
3. **Unit Testing with NUnit**
   - Transitioned to the **NUnit Framework**, focusing on structured test suites.
   - Mastered the **"One Assert per Method"** rule to ensure test clarity and precise failure identification.
   - Used `[TestFixture]` and `[Test]` attributes for test discovery.

#### Practical Tasks:
- Developed a flight validation engine and a rigorous bank account test suite.

  **Programs:**
  1. **AeroVigil – Flight & Fuel Manager:**
     - **Goal:** Validate flight data and calculate refueling needs.
     - **Implementation:** - Used `String.Split(':')` to parse input: `FlightNumber:FlightName:PassengerCount:CurrentFuelLevel`.
       - **Regex Validation:** Enforced the `FL-XXXX` pattern for flight numbers.
       - **Logic:** Verified airlines against an approved list (SpiceJet, Vistara, IndiGo, Air Arabia).
       - **Validation:** Checked passenger counts against aircraft-specific capacities (e.g., Vistara: 615) and ensured fuel levels were within limits.
       - **Calculation:** Output the remaining fuel required to reach the tank's max capacity.

  2. **Bank Account NUnit Test Suite:**
     - **Goal:** Create a 100% code coverage test suite for `Deposit` and `Withdraw` operations.
     - **Test Cases:**
       - **Valid Deposit:** Confirmed balance increases.
       - **Negative Deposit:** Used `Assert.Throws<Exception>` to catch invalid inputs.
       - **Valid Withdrawal:** Confirmed balance decreases correctly.
       - **Insufficient Funds:** Validated that overdrawing triggers a specific error message.



| Test Case | Method Target | Input Condition | Expected Result |
| :--- | :--- | :--- | :--- |
| **Success Path** | Deposit / Withdraw | Positive / Sufficient | Balance Updates |
| **Error Path** | Deposit | Amount < 0 | Throws Exception |
| **Error Path** | Withdraw | Amount > Balance | Throws Exception |

**Key Learnings:**
- Mastered **CSV Parsing**, a critical skill for importing large datasets into C# applications.
- Learned the importance of **Constraint-Based Validation**: setting different rules (capacities/fuel limits) based on the object type (Flight Name).
- Understood the rigor of **NUnit**; specifically how to test for failure (Exceptions) just as thoroughly as success.
- Practiced the discipline of **Single Assertion testing**, which makes debugging failed tests much faster.

---

### Date: January 29, 2026 | Day: 31

#### Topics Covered:
1. **JSON Fundamentals**
   - Studied the lightweight data-interchange format and its key-value pair structure.
   - Understanding JSON Data Types: String, Number, Boolean, Null, Array (`[]`), and Object (`{}`).
2. **JSON Serialization & Deserialization**
   - **Reading (Deserializing):** Converting a JSON string from a file or API into a C# Object.
   - **Writing (Serializing):** Converting C# objects back into JSON strings for storage or transmission.
3. **Parsing & Navigation**
   - Exploring libraries like `System.Text.Json` (modern .NET) or `Newtonsoft.Json`.
   - Learned how to parse complex, nested JSON objects to extract specific data points without mapping the entire structure.
4. **Schema Validation**
   - Introduction to **JSON Schema**: Defining a blueprint for what a JSON file *must* look like.
   - Learning how to validate data against a schema to ensure required fields (like `FlightNumber` or `Balance`) exist and have the correct data types before processing.

#### Practical Study & Requirements:
- Focused on transitioning the logic from previous systems (like AddressBook and AeroVigil) into a JSON-compatible format.
- **Goals for the Day:**
  - Create valid JSON files representing a list of `Contact` or `Flight` objects.
  - Understand the concept of "Pretty Printing" (indented JSON) versus "Minified" JSON for network efficiency.
  - Explore how to handle **Nullable types** and **Date formats** during the serialization process.



**Key Learnings:**
- Realized that JSON is essentially the "String representation" of the **Dictionaries and HashMaps** built manually earlier this month.
- Understood that **Schema Validation** is the "Unit Test" for data; it prevents the system from crashing due to malformed external inputs.
- Gained a clear perspective on the differences between CSV (flat, simple) and JSON (hierarchical, complex) and when to use each for I/O handling.

---

### Date: January 30, 2026 | Day: 31

#### Topics Covered:
1. **Advanced Abstract Architecture**
   - Implemented an **Abstract Base Class** (`GoodsTransport`) to enforce a contract for specialized transport types.
   - Mastered **Constructor Chaining** to pass data from child classes (`BrickTransport`, `TimberTransport`) back to the base protected attributes.
   - Applied **Method Overriding** to calculate dynamic costs and select vehicles based on physical dimensions (volume vs. quantity).
2. **String Analytics & Transformation**
   - Developed a complex "Lexical Twist" engine focusing on **Case-Insensitive Comparisons** and **Reverse-String logic**.
   - Practiced **Character Analysis** to filter unique vowels and consonants while strictly avoiding built-in collections.
3. **Robust Input Validation**
   - Used **Utility Classes** to centralize parsing logic (`parseDetails`) and data validation (Regex for Transport ID).
   - Implemented strict error handling to stop processing when invalid characters (spaces) are detected, without forcing a system-level exit.

#### Practical Tasks:
- Developed two comprehensive systems requiring high-level algorithmic thinking and clean C# coding standards.

  **Programs:**
  1. **FutureLogistics – Automated Billing System:**
     - **Goal:** Automate charge calculations for a transport company.
     - **Transport Logic:**
       - **BrickTransport:** Vehicle selection based on quantity ($<300$ for Truck, etc.). Total charge included a base price + 30% tax + vehicle fee, minus a rating-based discount.
       - **TimberTransport:** Vehicle selection based on Surface Area ($2 \times 3.147 \times r \times l$). Charge calculated via Volume formula.
     - **Utility Logic:** Created a `parseDetails` method to handle colon-separated strings, validating the ID format before instantiation.

  2. **Lexical Twist – Word Puzzle Engine:**
     - **Goal:** Perform divergent transformations based on string symmetry.
     - **Path A (Reversed Words):** If Word 2 is the reverse of Word 1, the program reverses the string, lowers the case, and masks all vowels with `@`.
     - **Path B (Non-Reversed):** If words don't match, they are concatenated and analyzed.
     - **Analytics:** Counted vowels and consonants to determine the dominant type, then used manual iteration to find and print exactly two **unique** characters of the winning type.
     - **Constraint Management:** Handled space-validation to ensure word integrity.



**Key Learnings:**
- Mastered the use of **Abstract Methods** to allow different child objects to have unique "selection" logic while sharing common data.
- Learned to handle **Geometric Math** ($2 \times \pi \times r \times l$) within a business application context.
- Refined **String Buffer/Builder** logic for reversing and masking characters manually.
- Solidified the practice of using **Utility Classes** to keep the `Main` interface clean and focused solely on user interaction.

---
### Date: January 31, 2026 | Day: 32

#### Topics Covered:
1. **Advanced JSON Manipulation**
   - **Serialization/Deserialization:** Converting complex C# objects and lists into formatted JSON arrays and back.
   - **Data Merging & Filtering:** Implementing logic to merge separate JSON files and filter records based on specific criteria (e.g., `Age > 25`).
   - **Format Interoperability:** Practiced converting data between different standards: **CSV ↔ JSON ↔ XML**.
2. **Data Privacy & Sanitization (Censorship)**
   - Learned the concept of "Data Redaction"—permanently masking or removing sensitive information from datasets before storage or sharing.
3. **Schema-Based Validation**
   - Used `Newtonsoft.Json.Schema` to enforce structural integrity, ensuring that fields like `Email` follow valid patterns during the I/O process.

#### Practical Tasks:
- Completed a comprehensive set of 15+ hands-on JSON exercises and a major capstone project involving IPL sports data.

  **Major Project: IPL and Censorship Analyzer**
  - **Objective:** Build a cross-format (JSON/CSV) data processor that applies strict privacy rules to sports records.
  - **Core Logic:**
    - **Team Masking:** Developed a `MaskTeamName()` utility that identifies team names and replaces specific segments with `***`.
    - **Player Redaction:** Implemented a global redaction rule to replace the `player_of_match` field with the constant `REDACTED`.
  - **Multi-Format Pipeline:**
    - **Reader:** Built a unified reader to ingest both `.json` and `.csv` versions of match data.
    - **Transformer:** Applied the censorship rules to the in-memory object list.
    - **Writer:** Generated fresh output files (`censored_ipl.json` and `censored_ipl.csv`) reflecting the sanitized state.

  **JSON Skill Drill Highlights:**
  - Merged two distinct student database files into a single JSON object.
  - Successfully parsed a JSON blob to extract specific keys/values for a summary report.
  - Implemented a database-to-JSON exporter logic simulation.



**Key Learnings:**
- Mastered the ability to handle **Heterogeneous Data Sources**—reading from CSV and outputting to JSON seamlessly.
- Understood that **Data Transformation** is a multi-step process: Parse → Filter/Transform → Validate → Write.
- Gained hands-on experience with **Schema Validation**, realizing that validating an Email at the JSON level is just as important as validating it in the UI.
- Effectively used **String Manipulation** (like `.Replace()` or Regex) within the context of structured data files to achieve the "Censorship" requirement.

---

### Date: February 2, 2026 | Day: 33

#### Topics Covered:
1. **Software Design Principles (The Foundation)**
   - **SOLID:** Mastered the five core principles (Single Responsibility, Open/Closed, Lisket Substitution, Interface Segregation, and Dependency Inversion) to ensure code is robust and easy to scale.
   - **DRY (Don't Repeat Yourself):** Focused on eliminating code redundancy by creating reusable methods and utility classes.
   - **KISS (Keep It Simple, Stupid):** Prioritizing clarity over unnecessary complexity in system design.
2. **Design Patterns (Creational, Structural, Behavioral)**
   - Explored 10 essential patterns, including:
     - **Singleton:** Ensuring a class has only one instance (perfect for Logger or Database connections).
     - **Factory:** Decoupling object creation from the main logic.
     - **Observer:** Enabling a subscription mechanism to notify multiple objects about events.
3. **Advanced C# Functional Concepts**
   - **Delegates & Events:** Understood how to pass methods as arguments and build event-driven architectures.
   - **Lambda Expressions:** Using `=>` to write concise, anonymous functions for filtering and processing data.
4. **Asynchronous Programming (Multi-Programming)**
   - **Async/Await:** Learned how to perform non-blocking operations, essential for I/O and Network calls.
   - **Logging & Lifecycle:** Implemented structured logging to track when a process **Starts** and **Stops**, capturing the execution flow of background tasks.

#### Practical Application:
- **Mini-Project Refactoring:** Integrated these professional standards into the existing system (like the AddressBook or IPL Analyzer).

  **Implementation Highlights:**
  - **Async Logging:** Created an asynchronous logging service that writes system events to a file without freezing the User Interface.
  - **Lambda Integration:** Replaced bulky `foreach` loops in the IPL Analyzer with concise Lambda queries for filtering teams and players.
  - **Singleton Pattern:** Applied the Singleton pattern to the "Settings" and "Database Connection" modules of the project to prevent resource leaks.
  - **Event-Driven UI:** Used Delegates and Events to trigger notifications whenever a record is successfully censored or a file is saved.



**Key Learnings:**
- Realized that **SOLID** is not just a theory; it's a blueprint for writing code that doesn't break when requirements change.
- Understood that **Async/Await** is vital for modern applications to remain responsive while handling heavy I/O tasks.
- Gained a "design-first" mindset—thinking about *how* classes should interact before writing the first line of code.
- Learned the importance of **Logging** as the "black box" of an application, especially when debugging multi-threaded processes.

---
### Date: February 3, 2026 | Day: 34

#### Topics Covered:
1. **Domain-Specific Exception Handling**
   - Implemented a custom exception class `RobotSafetyException` inheriting from the base `Exception` class.
   - Practiced **Guard Clauses**: Validating inputs (Precision, Density, State) at the very beginning of the method to prevent invalid calculations.
2. **Business Logic & Formula Implementation**
   - Translated industrial safety requirements into a mathematical model using conditional logic and constant factors.
   - **Case-Sensitivity Management:** Ensuring the `machineryState` strictly matches "Worn", "Faulty", or "Critical".
3. **Architecture & Clean Code**
   - Followed the **Single Responsibility Principle (SRP)**: The `RobotHazardAuditor` class is solely responsible for calculation, while the `Program` class handles user interaction.
   - Practiced **Graceful Error Handling**: Using `try-catch` blocks to capture and display specific safety messages without crashing the application.

#### Practical Tasks:
- Developed the **Factory Robot Hazard Analyzer**, a system to calculate safety risks in a manufacturing environment.

  **Implementation Details:**
  - **Custom Exception:** `RobotSafetyException` designed to carry specific error messages to the `Main` method.
  - **Validation Logic:**
    - `armPrecision`: Must be $0.0 \leq x \leq 1.0$.
    - `workerDensity`: Must be $1 \leq x \leq 20$.
    - `machineryState`: Must be one of the three defined states (case-sensitive).
  - **The Risk Formula:**
    - Integrated the Machine Risk Factors ($Worn=1.3$, $Faulty=2.0$, $Critical=3.0$).
    - Formula: $$Hazard Risk = ((1.0 - armPrecision) \times 15.0) + (workerDensity \times machineRiskFactor)$$

  **Results:**
  - **Success Path:** Input (0.5, 10, "Critical") yields a score of **37.5**.
  - **Error Path:** Any out-of-range input triggers the custom exception, displaying the exact validation error (e.g., "Error: Worker density must be 1-20").

**Key Learnings:**
- Mastered the pattern of **Throwing vs. Catching**: The Auditor throws the specific safety error, while the UI catches and presents it to the user.
- Understood the importance of **Case Sensitivity** in industrial states—"Critical" is not the same as "critical" in high-stakes logic.
- Applied the **DRY (Don't Repeat Yourself)** principle by centralizing all risk logic within a single method.
- Realized that in professional systems, **Validation is 50% of the code**; the actual formula is often simple once the data is guaranteed to be clean.

---
### Date: February 4, 2026 | Day: 35

#### Topics Covered:
1. **Relational Database Management System (RDBMS)**
   - **Schema Design:** Mastered **ER Diagrams** and **Normalization** (1NF, 2NF, 3NF) to eliminate data redundancy.
   - **SQL Command Toolkit:**
     - **DDL:** `CREATE`, `ALTER`, `DROP` (Auto-committed).
     - **DML/DQL:** `INSERT`, `UPDATE`, `DELETE`, and the difference between **Selection** (filtering rows via `WHERE`) vs. **Projection** (choosing columns via `SELECT`).
     - **TCL:** `COMMIT` and `ROLLBACK` for maintaining data integrity.
   - **Advanced Querying:** Grouping and ordering data using `GROUP BY`, `HAVING`, and `ORDER BY`.

2. **Parallel Programming & Performance Optimization**
   - **Multi-Threading:** Using `Thread` and `Task` to perform concurrent DB operations.
   - **Synchronization:** Implementing locks and connection counters to prevent "Race Conditions" when multiple threads hit the DB.
   - **Performance Benchmarking:** Recording "Start and Stop" timestamps to calculate execution time (ms) to prove the efficiency of threaded vs. non-threaded operations.

#### Practical Tasks:
- Developed the **Employee Payroll Multi-Threaded System**, integrating MS SQL/MySQL with ADO.NET.

  **Project Milestones (UC 1 - 6):**
  - **UC 1 (Transactional Integrity):** Added multiple employees to the `payroll_service` DB using **ADO.NET Transactions** to ensure that if one part of the insert fails, the whole operation rolls back.
  - **UC 2-4 (Threading & Concurrency):** - Refactored the insertion logic to run on separate threads. 
    - Demonstrated a significant performance boost compared to sequential processing.
    - Used **Console Logs** and **Connection Counters** to visualize thread execution.
  - **UC 5 (Dependent Threading):** Handled complex relational inserts. Since `payroll_details` depends on `employee_id`, I synchronized threads to ensure the parent record exists before the child record is inserted.
  - **UC 6 (Mass Updates):** Implemented multi-threaded salary updates across multiple tables (`employee_payroll` and `payroll_details`), ensuring data consistency between the DB and the C# Object Model.



**Key Learnings:**
- **TDD (Test Driven Development):** Used **MSTest** to write failing tests first, then developed the code to pass them, ensuring 100% functional reliability.
- **Thread Safety:** Learned that "Faster" isn't always "Better" if data gets corrupted—**Synchronization** is key when threads share a database connection.
- **ACID Properties:** Understood how Transactions ensure Atomicity, Consistency, Isolation, and Durability in the Payroll system.
- **Relational Logic:** Mastered the use of **Joins** to pull data across normalized tables.

---

### Date: February 5, 2026 | Day: 36

#### Topics Covered:
1. **Advanced MSSQL Programming**
   - **Stored Procedures & UDFs:** Learned to move business logic from the application layer into the database for performance and security.
   - **Views & Abstraction:** Created virtual tables to simplify complex joins and provide data security for different user roles.
   - **Triggers & Cursors:** Implemented triggers for automated auditing and cursors for complex row-by-row data processing.
   - **Indexing:** Studied how to optimize search performance on frequently queried columns (like Patient IDs or Citizen Names).

2. **Project 1: Health Clinic Management System (DB Focus)**
   - **Schema Design:** Designed a normalized database across 6 modules (Patient, Doctor, Appointment, Visit, Billing, Admin).
   - **Key Logic (UC 1-6):**
     - **Patient/Doctor Management:** Handled "Soft Deletes" and uniqueness constraints.
     - **Appointment Scheduling:** Implemented "Availability Checks" using `GROUP BY` and `COUNT` to prevent overbooking.
     - **Billing & Revenue:** Used Aggregate Functions (`SUM`, `HAVING`) to generate itemized bills and revenue reports.
     - **Auditing:** Developed Triggers to log every `INSERT/UPDATE/DELETE` into a system audit table.

3. **Project 2: TechVille Smart City (Architecture Focus)**
   - **Phase 1 (The Foundation):** Initiated Modules 1–5, focusing on basic I/O, logical constructs, and memory management (JVM/Arrays).
   - **Strategic Goal:** To build a system that evolves from simple variables to complex Generic Containers (`CityContainer<T>`), Design Patterns, and I/O Streams.

**Key Learnings for the Day:**
-Database-First vs. Code-First: Learned how to balance logic between the SQL Server (Stored Procedures) and the C# Application (Modules).
-Memory Optimization: Understanding JVM/CLR memory management to handle the "Smart Citizen Database" efficiently as it grows from 1,000 to 100,000+ records.
-Data Integrity: Using Foreign Keys and Transactions in the Clinic App to ensure that a visit cannot exist without a valid patient and doctor.
---
This marks the beginning of the training program with a strong foundation. Future updates will include more advanced topics, practical tasks, and learnings. Stay tuned!

