# 🚀 2D Multi-Elevator Simulation (Unity 6)

A production-quality 2D elevator system simulation built in Unity, demonstrating clean architecture, intelligent dispatching, animation-driven interactions, and scalable system design.

---

## 🎯 Overview

This project simulates a building with multiple elevators responding to floor requests in a realistic and efficient manner. It focuses on:

* Smart elevator selection
* Independent elevator behavior
* Smooth movement between floors
* Animation-driven door system
* Clean, modular code architecture

---

## 🛗 Features

* 4 fully functional elevators
* 5 floors (Ground to 4th floor)
* Floor call buttons (Up / Down)
* Intelligent elevator dispatch system
* Direction-aware request handling
* Request deduplication system
* Smooth elevator movement
* Sprite-based animated doors
* Real-time elevator status display
* Scalable and maintainable code structure

---

## 🧠 System Design

### 🔹 Core Components

**ElevatorSystemManager**

* Central dispatcher responsible for assigning elevators
* Uses a scoring-based algorithm to select the best elevator

**ElevatorController**

* Handles movement, queue processing, and state transitions
* Maintains its own request queue

**ElevatorDoor**

* Manages door animations using Unity Animator
* Uses Animation Events for precise timing

**FloorButton**

* Sends floor requests with direction (Up/Down)

**ElevatorUI**

* Displays current floor and state of each elevator

---

## ⚙️ Dispatch Logic

Elevator selection is based on:

* Distance from requested floor
* Current direction of movement
* Idle vs moving state

Priority:

1. Idle elevators closest to the request
2. Elevators already moving toward the request
3. Penalize elevators moving in opposite direction

---

## 🎬 Animation System

* Door animations are sprite-based (frame animation)
* Controlled using Unity Animator
* Animation Events are used to:

  * Detect when door fully opens/closes
  * Synchronize gameplay logic with visuals

---

## 🕹️ How to Run

1. Open the project in Unity 6
2. Load the `Main` scene
3. Press Play
4. Use floor buttons to call elevators
5. Observe elevator behavior and door animations

---

## 🧪 Key Technical Highlights

* Coroutine-based state machine for elevator flow
* Event-driven animation synchronization
* Request lifecycle management (prevents duplicate calls)
* Scalable architecture supporting multiple elevators
* Clean separation of UI and logic

---

## ⚠️ Challenges Solved

* Preventing multiple elevators responding to the same request
* Synchronizing movement with door animations
* Avoiding deadlocks in request processing
* Managing independent queues for each elevator

---

## 👨‍💻 Author

**Abhishek Sarin**
Unity Developer

---

## ⭐ If You Like This Project

Feel free to star the repo or use it as a reference for system design in Unity.

---

