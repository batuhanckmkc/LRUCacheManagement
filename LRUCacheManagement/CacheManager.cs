using System.Collections.Generic;
using LRUCacheManagement.Interface;

namespace LRUCacheManagement
{
    public class CacheManager : ICache
    {
        private int _memorySizeLimit = 5;
        private int _currentMemoryCount = 0;
        
        public readonly Dictionary<int, Node> PhotoDict = new Dictionary<int, Node>();
        private readonly LinkedList _linkedList;
        public CacheManager(LinkedList linkedList)
        {
            _linkedList = linkedList;
        }

        public Node Get(int key)
        {
            if (PhotoDict.TryGetValue(key, out Node foundNode))
            {
                _linkedList.Remove(foundNode);
                _linkedList.Add(foundNode);
                return foundNode;
            }
            return null;
        }

        public bool TrySet(int key, string photoUrl)
        {
            if (PhotoDict.TryGetValue(key, out var existingNode))
            {
                existingNode.PhotoUrl = photoUrl;
                _linkedList.Remove(existingNode);
                _linkedList.Add(existingNode);
                return true;
            }
            var newNode = new Node(key, photoUrl);
            PhotoDict.Add(key, newNode);
            
            if (_currentMemoryCount < _memorySizeLimit)
            {
                _linkedList.Add(newNode);
                _currentMemoryCount++;
            }
            else
            {
                var evictedNode = _linkedList.RemoveOldest();
                PhotoDict.Remove(evictedNode.Key);
                _linkedList.Add(newNode);
            }
            return true;
        }
    }
}