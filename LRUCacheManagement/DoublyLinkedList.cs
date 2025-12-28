using System.Collections;
using System.Collections.Generic;

namespace LRUCacheManagement
{
    public class Node
    {
        public int Key;
        public string PhotoUrl;
        public Node Next;
        public Node Prev;

        public Node(int key, string photoUrl)
        {
            Key = key;
            PhotoUrl = photoUrl;
            Next = null;
            Prev = null;
        }
    }
    
    public class DoublyLinkedList : LinkedList, IEnumerable<Node>
    {
        private Node _head, _tail;

        public DoublyLinkedList()
        {
            _head = new Node(0, null);
            _tail = new Node(0, null);

            _head.Next = _tail;
            _tail.Prev = _head;
        }

        private void AddToHead(Node newNode)
        {
            newNode.Next = _head.Next;
            newNode.Prev = _head;
            
            _head.Next.Prev = newNode;
            _head.Next = newNode;
        }

        public override void Remove(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            Node currentNode = _head.Next;
            while (currentNode != _tail)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        public override void Add(Node node)
        {
            AddToHead(node);
        }

        public override Node RemoveOldest()
        {
            var oldestNode = _tail.Prev;
            Remove(oldestNode);
            
            return oldestNode;
        }
    }
}