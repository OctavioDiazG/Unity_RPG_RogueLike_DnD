
public interface IStorageRemove<T>
{
    public bool Remove(T item, int amount, out int removed);
}
