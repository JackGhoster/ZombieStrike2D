
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    [SerializeField]
    private InventoryObject _inventory;


    [SerializeField]
    private Button _deleteButton;


    private void Start()
    {
        _deleteButton.onClick.AddListener(RemoveItem);
    }

    public void RemoveItem()
    {
        print("Removed");
        var item = this.gameObject.GetComponent<Item>();

        if (item)
        {
            _inventory.RemoveItem(item.ItemObj);
            _inventory.Save();
        }
        var hasItem = false;
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            if (_inventory.Slots[i].Item == item.ItemObj)
            {
                hasItem = true;
            }
            else
            {
                hasItem = false;
            }
        }
        if (!hasItem)
        {
           Destroy(_deleteButton.transform.parent.gameObject); 
        }
    }
}
