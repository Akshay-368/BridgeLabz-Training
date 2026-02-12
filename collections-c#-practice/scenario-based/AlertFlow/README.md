
---

##  **Overview**

```md
# 🚀 AlertFlow  
### Intelligent Concurrent Alert Processing System (.NET 6)

![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Programming-239120?logo=c-sharp)
![Concurrency](https://img.shields.io/badge/System-Parallel%20Processing-blue)
![Status](https://img.shields.io/badge/Project-Academic%20%7C%20Portfolio-success)

---

## 📖 Overview

**AlertFlow** is a high-efficiency, console-based alert management system developed using **C# and .NET 6+**.

It showcases practical backend engineering techniques such as:

- Asynchronous task execution (`async/await`)
- Multithreaded processing with task parallelism
- Priority-driven workload handling
- Thread-safe data structures
- Layered system design
- SOLID-oriented development approach

The system allows users to generate and process alerts (Email, SMS, App Notifications) concurrently, ensuring stable performance even during peak workloads.

---

## ✨ Key Features

- ⚡ Fully asynchronous execution model
- 🎯 Priority-driven alert scheduling using `PriorityQueue`
- 🔒 Safe state handling via `ConcurrentDictionary`
- 🧠 Strategy and Factory design patterns
- 🧩 Modular and maintainable architecture
- 🛡 Fault isolation for individual tasks

---

## 🏗 System Architecture

AlertFlow follows a scalable layered architecture:

```

User Interface Layer
↓
Processing Layer (Business Logic & Scheduling)
↓
Strategy Layer (Delivery Abstraction)
↓
Domain & Validation Layer

```

### 🔹 User Interface Layer
Manages console-based interaction and command handling.

### 🔹 Processing Layer
Responsible for:
- Alert lifecycle management
- Worker task scheduling
- Priority queue execution
- Parallel coordination

### 🔹 Strategy & Factory Layer
- `IAlertSender` interface
- Channel-specific implementations
- `AlertDispatcherFactory` for runtime binding

### 🔹 Domain & Validation Layer
- Alert models
- DataAnnotations
- Custom recipient validation attributes

---

## 📂 Directory Layout

```

AlertFlow/
│
├── Program.cs
├── AlertMain.cs
├── AlertMenu.cs
├── IAlertService.cs
├── AlertServiceManager.cs
├── Alert.cs
├── AlertValidator.cs
├── AlertRecipientAttribute.cs
├── AlertDispatcherFactory.cs
├── IAlertSender.cs
├── Senders/
│     ├── EmailDispatcher.cs
│     ├── SmsDispatcher.cs
│     └── AppNotifier.cs
└── README.md

```

---

## ⚙️ Core Capabilities

### 1️⃣ Multi-Platform Alert Delivery

- 📧 Email
- 📱 SMS
- 🔔 Application Alerts

Delivery channels are selected dynamically using the Strategy Pattern.

---

### 2️⃣ Priority-Based Scheduling

Built using:

```

PriorityQueue<TElement, TPriority>

````

| Priority Level | Value |
|----------------|--------|
| Critical       | 1 |
| Normal         | 2 |
| Low            | 3 |

Lower values represent higher urgency.

---

### 3️⃣ Parallel Worker Architecture

- Background processing via `Task.Run()`
- Asynchronous execution with `async/await`
- Thread synchronization using `lock`
- State monitoring with `ConcurrentDictionary`

✔ Input requests never block execution  
✔ Multiple alerts handled simultaneously  

---

### 4️⃣ Validation & Consistency Checks

Validation is enforced using:

- `System.ComponentModel.DataAnnotations`
- Custom `AlertRecipientAttribute`

Validation Rules:

- Alert ID → Mandatory
- Message → Mandatory
- Recipient → Channel-specific format:
  - Email → Valid address
  - SMS → 10-digit number
  - App Alert → Ends with `.notify`

---

### 5️⃣ Reliability & Status Monitoring

Each alert is processed independently.

Lifecycle states:

- Queued
- Active
- Delivered
- Error

Failures in one process do **not** interrupt others.

---

## 🧵 Concurrency Framework

| Component | Function |
|-----------|----------|
| `PriorityQueue` | Execution ordering |
| `ConcurrentDictionary` | Safe state tracking |
| `Task` | Parallel processing |
| `async/await` | Non-blocking execution |
| `lock` | Critical section control |

This design ensures performance without compromising safety.

---

## 🏛 Software Engineering Principles

- ✅ Encapsulation
- ✅ Abstraction
- ✅ Inheritance
- ✅ Polymorphism
- ✅ Strategy Pattern
- ✅ Factory Pattern
- ✅ Open/Closed Principle
- ✅ Separation of Concerns
- ✅ Single Responsibility Principle

---

## 🖥 Setup & Usage

### 🔧 Requirements

- .NET 6 SDK or newer
- Visual Studio 2022 / VS Code

### ▶ Run Instructions

```bash
git clone <repository-url>
cd AlertFlow
dotnet build
dotnet run
````

---

## 🧪 Example Workflow

```
1. Create Alert
2. View Active Alerts
3. Exit System
```

1. User submits alert
2. Validation executed
3. Queued by priority
4. Workers process asynchronously
5. Status updated live

---

## 📈 Performance & Scalability

AlertFlow is built for growth:

* Asynchronous execution
* Isolated task management
* Thread-safe structures
* Priority scheduling
* Expandable delivery modules

Future enhancements may include:

* Database storage
* Distributed messaging queues
* RESTful API services
* Configurable worker pools

---

## 🛠 Development Stack

* C#
* .NET 6+
* Task-based Asynchronous Pattern (TAP)
* Collections Framework
* Concurrent Collections
* DataAnnotations
* Custom Attributes

---

# 🏁 Summary

AlertFlow demonstrates how modern .NET systems can utilize parallel execution and concurrency tools to deliver responsive and scalable backend solutions.

It reflects strong proficiency in:

* Parallel programming
* System architecture
* Design patterns
* Reliability engineering
* Industry-level coding standards
