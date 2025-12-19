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


This marks the beginning of the training program with a strong foundation. Future updates will include more advanced topics, practical tasks, and learnings. Stay tuned!

