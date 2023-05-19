
public interface ISlotRemove<T>
{
    public bool Remove(T item, int amount, out int removed);
}
