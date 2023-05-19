using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOperations : MonoBehaviour
{
    [SerializeField] private GameObject m_CursorSlot;
    [SerializeField] private GameObject m_UIRaycast;

    private IStorageAdd<ItemAsset> cursorAdd;
    private IStorageRemove<ItemAsset> cursorRemove;
    private IStorageValue<ItemAsset> cursorValue;
    private IFactory<RaycastResult[]> uiRaycast;

    private void Awake()
    {
        cursorAdd = m_CursorSlot.GetComponent<IStorageAdd<ItemAsset>>();
        cursorRemove = m_CursorSlot.GetComponent<IStorageRemove<ItemAsset>>();
        cursorValue = m_CursorSlot.GetComponent<IStorageValue<ItemAsset>>();
        uiRaycast = m_UIRaycast.GetComponent<IFactory<RaycastResult[]>>();
    }

    public void SwitchItems()
    {
        IStorageAdd<ItemAsset> otherAdd;
        IStorageRemove<ItemAsset> otherRemove;
        IStorageValue<ItemAsset> otherValue;
        if (!GetSlot(out otherAdd, out otherRemove, out otherValue))
            return;

        otherValue.GetValue(out ItemAsset otherItem, out int otherCount);
        cursorValue.GetValue(out ItemAsset cursorItem, out int cursorCount);

        if(otherItem && !cursorItem)
        {
            if (!cursorAdd.Add(otherItem, otherCount, out int cursorAdded))
                return;
            otherRemove.Remove(otherItem, cursorAdded, out int otherRemoved);
            return;
        }

        if(!otherItem && cursorItem)
        {
            if (!otherAdd.Add(cursorItem, cursorCount, out int otherAdded))
                return;
            cursorRemove.Remove(cursorItem, otherAdded, out int cursorRemoved);
            return;
        }

        if(otherItem && cursorItem)
        {
            if (otherItem.Type != cursorItem.Type)
                return;

            otherRemove.Remove(otherItem, otherCount, out int otherRemoved);
            otherAdd.Add(cursorItem, cursorCount, out int otherAdded);
            cursorRemove.Remove(cursorItem, cursorCount, out int cursorRemoved);
            cursorAdd.Add(otherItem, otherCount, out int cursorAdded);
        }
    }

    public void AddItem()
    {
        IStorageAdd<ItemAsset> otherAdd;
        IStorageRemove<ItemAsset> otherRemove;
        IStorageValue<ItemAsset> otherValue;
        if (!GetSlot(out otherAdd, out otherRemove, out otherValue))
            return;

        otherValue.GetValue(out ItemAsset otherItem, out int otherCount);
        cursorValue.GetValue(out ItemAsset cursorItem, out int cursorCount);

        if (!otherAdd.Add(cursorItem, cursorCount, out int otherAdded))
            return;
        cursorRemove.Remove(cursorItem, otherAdded, out int cursorRemoved);
    }

    public void PickItem()
    {
        IStorageAdd<ItemAsset> otherAdd;
        IStorageRemove<ItemAsset> otherRemove;
        IStorageValue<ItemAsset> otherValue;
        if (!GetSlot(out otherAdd, out otherRemove, out otherValue))
            return;

        otherValue.GetValue(out ItemAsset otherItem, out int otherCount);
        cursorValue.GetValue(out ItemAsset cursorItem, out int cursorCount);

        if (!cursorAdd.Add(otherItem, 1, out int cursorAdded))
            return;
        otherRemove.Remove(otherItem, cursorAdded, out int otherRemoved);
    }

    public void LeaveItem()
    {
        IStorageAdd<ItemAsset> otherAdd;
        IStorageRemove<ItemAsset> otherRemove;
        IStorageValue<ItemAsset> otherValue;
        if (!GetSlot(out otherAdd, out otherRemove, out otherValue))
            return;

        otherValue.GetValue(out ItemAsset otherItem, out int otherCount);
        cursorValue.GetValue(out ItemAsset cursorItem, out int cursorCount);

        if (!otherAdd.Add(cursorItem, 1, out int otherAdded))
            return;
        cursorRemove.Remove(cursorItem, otherAdded, out int cursorRemoved);
    }

    private bool GetSlot(out IStorageAdd<ItemAsset> add, out IStorageRemove<ItemAsset> remove, out IStorageValue<ItemAsset> value)
    {
        add = null;
        remove = null;
        value = null;

        RaycastResult[] result = uiRaycast.Create();
        if (result.Length == 0) return false;

        GameObject otherSlot = result[0].gameObject;
        add = otherSlot.GetComponent<IStorageAdd<ItemAsset>>();
        remove = otherSlot.GetComponent<IStorageRemove<ItemAsset>>();
        value = otherSlot.GetComponent<IStorageValue<ItemAsset>>();
        return !(add == null || remove == null || value == null);
    }
}
