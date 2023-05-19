
public interface IStorageAdd<T>
{
    public bool Add(T item, int amount, out int added);
}
