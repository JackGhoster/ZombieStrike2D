using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickuper : MonoBehaviour
{
    [SerializeField]
    private InventoryObject _inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        if (item)
        {
            _inventory.AddItem(item.ItemObj, 1);
            Destroy(collision.gameObject);
        }
    }
}
