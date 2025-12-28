using System;

namespace LRUCacheManagement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
            CacheManager cacheManager = new CacheManager(doublyLinkedList);
            
            cacheManager.TrySet(15, "Sun");
            cacheManager.TrySet(5, "Glass");
            cacheManager.TrySet(10, "Ball");

            // var foundNode = cacheManager.Get(15);
            // doublyLinkedList.Remove(foundNode);
            doublyLinkedList.RemoveOldest();
            foreach (var node in doublyLinkedList)
            {
                Console.Write(" -----> " + node.Key + " Next: " + node.Next.Key);
            }
        }
    }
}