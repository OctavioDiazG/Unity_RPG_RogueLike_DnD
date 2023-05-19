using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlotInventory : MonoBehaviour
{
    private struct SlotData
    {
        public ISlotAdd<ItemAsset> m_Add;
        public ISlotRemove<ItemAsset> m_Remove;
        public ISlotValue<ItemAsset> m_Value;

        public SlotData(ISlotAdd<ItemAsset> add, ISlotRemove<ItemAsset> remove, ISlotValue<ItemAsset> value)
        {
            m_Add = add;
            m_Remove = remove;
            m_Value = value;
        }
    }

    [SerializeField] private ItemSlot m_Slot;
    [SerializeField] private GameObject[] m_Slots;
    [SerializeField] private ItemAsset m_Item;
    [SerializeField] private int m_Count;

    private List<SlotData> m_SlotDatas;

    private void Awake()
    {
        m_SlotDatas = new();
        for(int i=0; i<m_Slots.Length; i++)
        {
            // Obtenemos los componentes de los slots
            GameObject s = m_Slots[i];
            ISlotAdd<ItemAsset> add = s.GetComponent<ISlotAdd<ItemAsset>>();
            ISlotRemove<ItemAsset> remove = s.GetComponent<ISlotRemove<ItemAsset>>();
            ISlotValue<ItemAsset> value = s.GetComponent<ISlotValue<ItemAsset>>();
            m_SlotDatas.Add(new SlotData(add, remove, value));
        }
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Recorre todos los slots para comprobar si pudo agregar
            // el item al inventario
            int temp = m_Count;
            for (int i = 0; i < m_SlotDatas.Count; i++)
            {
                // Si pudo añadir el item al slot
                if(m_SlotDatas[i].m_Add.Add(m_Item, temp, out int added))
                {
                    // Descuenta la cantidad añadida
                    temp -= added;
                    if (temp == 0) return;
                }
            }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            // Recorre todos los slots para comprobar si pudo quitar
            // el item del inventario
            int temp = m_Count;
            for (int i = 0; i < m_SlotDatas.Count; i++)
            {
                // Si pudo quitar el item del slot
                if (m_SlotDatas[i].m_Remove.Remove(m_Item, temp, out int removed))
                {
                    // Descuenta la cantidad quitada
                    temp -= removed;
                    if (temp == 0) return;
                }
            }
        }
    }
}
