
/*
 * Interfaz que implementan los objetos que tienen como
 * objetivo crear instancias de otros objetos
 */

public interface IFactory<T>
{
    public T Create();
}
