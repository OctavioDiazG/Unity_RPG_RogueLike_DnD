using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private ItemInvetory m_Inventory;
    [SerializeField] private ItemOperations m_Operations;
    [SerializeField] private ItemAsset m_Item;
    [SerializeField] private int m_Count;

    private void Update()
    {
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            m_Inventory.Add(m_Item, m_Count, out int added);
            print($"Agegué {added} items del tipo {m_Item.Name}");
            return;
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            m_Inventory.Remove(m_Item, m_Count, out int removed);
            print($"Quité {removed} items del tipo {m_Item.Name}");
            return;
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            m_Inventory.Find(m_Item, out int count);
            print($"Encontré {count} de {m_Item.Name}");
            return;
        }

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            m_Operations.SwitchItems();
            return;
        }

        if(Mouse.current.middleButton.wasPressedThisFrame)
        {
            m_Operations.AddItem();
            return;
        }

        if(Keyboard.current.leftShiftKey.isPressed && Mouse.current.rightButton.wasPressedThisFrame)
        {
            m_Operations.PickItem();
            return;
        }

        if(Mouse.current.rightButton.wasPressedThisFrame)
        {
            m_Operations.LeaveItem();
            return;
        }
    }
}
