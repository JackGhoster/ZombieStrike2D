using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{   
    public List<InventorySlot> Slots = new List<InventorySlot>();
    
    public void AddItem(ItemObject item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Item == item)
            {
                Slots[i].AddAmount(amount);
                hasItem = true;
                break;
            }  
        }
        if (!hasItem) 
        {
            Slots.Add(new InventorySlot(item, amount));
        }
    }
}

