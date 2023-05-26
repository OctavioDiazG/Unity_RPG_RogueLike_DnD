using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 5;
    public InventorySlots[] inventorySlots;
    public GameObject inventoryItemPrefab;

    private int _selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number is > 0 and < 10)
            {
                ChangeSelectedSlot(number-1);
            }
        }
    }

    private void ChangeSelectedSlot(int newValue)
    {
        if (_selectedSlot >= 0)
        {
            inventorySlots[_selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        _selectedSlot = newValue;
    }
    
    public bool AddItem(Items item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlots slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems
                && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        
        //find empty slotf
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlots slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                 SpawnNewItem(item,slot);
                 return true;
            }
        }
        
        return false;
    }

    void SpawnNewItem(Items item, InventorySlots slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Items GetSelectedItems(bool _use)
    {
        InventorySlots slot = inventorySlots[_selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Items item = itemInSlot.item;
            if (_use == true)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            } 
            return item;
        }

        return null;
    }
}
