
public interface IStorageFind<T>
{
    public bool Find(T item, out int count);
}
