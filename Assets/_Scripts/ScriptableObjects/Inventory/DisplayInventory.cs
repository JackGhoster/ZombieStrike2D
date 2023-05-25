using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField]
    private InventoryObject _inventory;
    
    Dictionary<InventorySlot, GameObject> _itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }
    void Update()
    {
        UpdateDisplay();
    }


    private void CreateDisplay()
    {
        for(int i = 0; i < _inventory.Slots.Count; i++)
        {
            var obj = Instantiate(_inventory.Slots[i].Item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.Slots[i].Amount.ToString("n0");
            _itemsDisplayed.Add(_inventory.Slots[i], obj);
        }
    }

  
 
    private void UpdateDisplay()
    {
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            if (_itemsDisplayed.ContainsKey(_inventory.Slots[i]))
            {
                _itemsDisplayed[_inventory.Slots[i]].GetComponentInChildren<TextMeshProUGUI>().text = _inventory.Slots[i].Amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(_inventory.Slots[i].Item.Prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.Slots[i].Amount.ToString("n0");
                _itemsDisplayed.Add(_inventory.Slots[i], obj);
            }
        }
       
    }
}
