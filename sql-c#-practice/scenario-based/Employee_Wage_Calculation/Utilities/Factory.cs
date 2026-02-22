namespace Utilities;

public static class Factory<K, T>
    where T : class, K, new()
{
    public static K Create()
    {
        return new T();
    }
}
