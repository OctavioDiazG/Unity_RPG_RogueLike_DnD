using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Items[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
        }
    }

    public void GetSelectedItem()
    {
        Items recievedItem = inventoryManager.GetSelectedItems(false);
        if (recievedItem != null)
        {
            Debug.Log("Recieved Item: " + recievedItem);
        }
        else
        {
            Debug.Log("No item recieved!");
        }
    }
    
    public void UseSelectedItem()
    {
        Items recievedItem = inventoryManager.GetSelectedItems(true);
        if (recievedItem != null)
        {
            Debug.Log("Used Item: " + recievedItem);
        }
        else
        {
            Debug.Log("No item used!");
        }
    }
}
