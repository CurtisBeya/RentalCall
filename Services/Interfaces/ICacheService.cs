namespace RentalCall.Services.Interfaces
{
    public interface ICacheService
    {
        //sets an item in the cache with a specified key and value, and sets the cache expiration to 1 day
        void Set<T>(string key, T value);

        //retrieves an item from the cache with a specified key and returns it as the specified type T
        T? Get<T>(string key);

        //removes an item from the cache with a specified key
        void Remove(string key);
    }
}
