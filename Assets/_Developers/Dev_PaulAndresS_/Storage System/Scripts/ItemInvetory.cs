using System.Collections.Generic;
using UnityEngine;

public class ItemInvetory : MonoBehaviour, IStorageAdd<ItemAsset>, IStorageRemove<ItemAsset>, IStorageFind<ItemAsset>
{
    private struct SlotData
    {
        public IStorageAdd<ItemAsset> m_Add;
        public IStorageRemove<ItemAsset> m_Remove;
        public IStorageValue<ItemAsset> m_Value;

        public SlotData(IStorageAdd<ItemAsset> add, IStorageRemove<ItemAsset> remove, IStorageValue<ItemAsset> value)
        {
            m_Add = add;
            m_Remove = remove;
            m_Value = value;
        }
    }

    [SerializeField] private GameObject[] m_Slots;

    private SlotData[] slotDatas;
    
    private void Awake()
    {
        slotDatas = new SlotData[m_Slots.Length];
        for(int i=0; i<m_Slots.Length; i++)
        {
            GameObject s = m_Slots[i];
            IStorageAdd<ItemAsset> add = s.GetComponent<IStorageAdd<ItemAsset>>();
            IStorageRemove<ItemAsset> remove = s.GetComponent<IStorageRemove<ItemAsset>>();
            IStorageValue<ItemAsset> value = s.GetComponent<IStorageValue<ItemAsset>>();
            slotDatas[i] = (new(add, remove, value));
        }
    }

    public bool Add(ItemAsset item, int amount, out int added)
    {
        int temp = amount;

        List<int> emptySlots = new();
        for(int i=0; i<slotDatas.Length; i++)
        {
            slotDatas[i].m_Value.GetValue(out ItemAsset slotItem, out int slotAmount);
            if(slotAmount == 0)
            {
                emptySlots.Add(i);
                continue;
            }

            if(slotDatas[i].m_Add.Add(item, temp, out int addedItems))
            {
                temp -= addedItems;
                if (temp == 0) break;
            }
        }

        for(int i=0; i<emptySlots.Count; i++)
        {
            int slot = emptySlots[i];
            if(slotDatas[slot].m_Add.Add(item, temp, out int addedItem))
            {
                temp -= addedItem;
                if (temp == 0) break;
            }
        }

        added = amount - temp;
        return true;
    }

    public bool Find(ItemAsset item, out int count)
    {
        count = 0;
        for(int i=0; i<slotDatas.Length; i++)
        {
            slotDatas[i].m_Value.GetValue(out ItemAsset slotItem, out int itemCount);
            if (slotItem == item && itemCount > 0) count += itemCount;
        }

        return count > 0;
    }

    public bool Remove(ItemAsset item, int amount, out int removed)
    {
        int temp = amount;

        for(int i= slotDatas.Length - 1; i>=0; i--)
        {
            if(slotDatas[i].m_Remove.Remove(item, temp, out int removedItems))
            {
                temp -= removedItems;
                if (temp == 0) break;
            }
        }

        removed = amount - temp;
        return true;
    }
}
