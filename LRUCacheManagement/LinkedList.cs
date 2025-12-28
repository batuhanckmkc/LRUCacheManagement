namespace LRUCacheManagement
{
    public abstract class LinkedList
    {
        public abstract void Remove(Node node);
        public abstract void Add(Node node);
        public abstract Node RemoveOldest();
    }
}