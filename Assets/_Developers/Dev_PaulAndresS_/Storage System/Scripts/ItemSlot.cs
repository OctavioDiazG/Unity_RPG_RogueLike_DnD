using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour, IStorageAdd<ItemAsset>, IStorageRemove<ItemAsset>, IStorageValue<ItemAsset>
{
    [SerializeField] private Image m_IconImage; // Imagen icono del slot
    [SerializeField] private TextMeshProUGUI m_CountText; // Texto de cantidad del slot
    [SerializeField] private string m_SlotType; // El tipo de item que acepta el slot

    private ItemAsset m_Item;
    private int m_Count;

    public bool Add(ItemAsset item, int amount, out int added)
    {
        // Asigna iniciarlmente a 0 la cantidad de items añadidos
        added = 0;

        if (item == null) return false;

        // Comprueba si el slot no está vacio y si es del tipo del item a agregar
        if (m_Count != 0 && !m_Item.Equals(item))
            return false;

        // Comprueba si el item a agregar es del tipo del item del slot
        if (m_SlotType.Length != 0 && item.Type != m_SlotType)
            return false;

        // Guarda el item y añade la cantidad disponible
        m_Item = item;
        added = Mathf.Clamp(amount, 0, m_Item.MaxStack - m_Count);
        if (added == 0) return false;
        m_Count += added;

        // Actualiza la interfaz de usuario
        m_IconImage.sprite = m_Item.Icon;
        m_CountText.text = m_Count <= 1 ? "" : m_Count.ToString();
        return true;
    }

    public void GetValue(out ItemAsset item, out int count)
    {
        // Regresa la informacion de los items
        item = m_Item;
        count = m_Count;
    }

    public bool Remove(ItemAsset item, int amount, out int removed)
    {
        // Asigna iniciarlmente a 0 la cantidad de items quitados
        removed = 0;

        if (item == null) return false;

        // Comprueba si el slot esta completamente vacio
        if (m_Count == 0)
            return false;

        // Comprueba si el slot no está vacio y si es del tipo del item a agregar
        if (m_Count != 0 && !m_Item.Equals(item))
            return false;

        // Comprueba si el item a agregar es del tipo del item del slot
        if (m_SlotType.Length != 0 && item.Type != m_SlotType)
            return false;

        // Quita la cantidad de items disponible
        removed = Mathf.Clamp(amount, 0, m_Count);
        if (removed == 0) return false;
        m_Count -= removed;
        
        // Si ya no hay items entonces no hace nada
        if (m_Count == 0) m_Item = null;

        // Actualiza la interfaz de usuario
        m_IconImage.sprite = m_Item?.Icon;
        m_CountText.text = m_Count <= 1 ? "" : m_Count.ToString();
        return true;
    }
}
