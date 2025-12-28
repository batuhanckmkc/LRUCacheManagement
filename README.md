# LRU Cache Management (C#)

This repository contains a high-performance **Least Recently Used (LRU) Cache** management designed for $O(1)$ time complexity for both `Get` and `TrySet` operations. It demonstrates advanced data structure management by combining the strengths of a **Dictionary** and a **Doubly Linked List**.

---

## 🚀 Key Features

* **$O(1)$ Complexity:** Fast data access and updates for high-performance requirements.
* **Upsert Capability:** Automatically updates existing keys and moves them to the "Most Recently Used" position.
* **Memory Efficiency:** Efficiently manages a fixed capacity, evicting the least recently used items when full.
* **Robust Architecture:** Uses **Dummy Head and Tail nodes** to eliminate null checks and handle edge cases gracefully.

---

## 🛠 Technical Architecture

To achieve maximum performance, the system uses a hybrid approach:

1.  **Dictionary<TKey, Node<TKey, TValue>>:** Provides instant lookup to any node in the list.
2.  **Doubly Linked List:** Maintains the order of elements based on usage.
    * **New/Updated items** are moved to the **Head** (Most Recently Used).
    * **Old items** are removed from the **Tail** (Least Recently Used).

## 📝 Example Usage

```csharp
DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
CacheManager cacheManager = new CacheManager(doublyLinkedList);
            
cacheManager.TrySet(15, "Sun");
cacheManager.TrySet(5, "Glass");
cacheManager.TrySet(10, "Ball");

var foundNode = cacheManager.Get(15);
doublyLinkedList.Remove(foundNode);
doublyLinkedList.RemoveOldest();
