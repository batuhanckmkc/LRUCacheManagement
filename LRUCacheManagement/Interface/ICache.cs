namespace LRUCacheManagement.Interface
{
    public interface ICache
    {
        Node Get(int key);
        bool TrySet(int key, string photoUrl);
    }
}