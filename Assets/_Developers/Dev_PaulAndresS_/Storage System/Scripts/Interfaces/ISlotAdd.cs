
public interface ISlotAdd<T>
{
    public bool Add(T item, int amount, out int added);
}
