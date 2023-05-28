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
        var item = this.gameObject.GetComponent<Item>();

        if (item)
        {
            _inventory.RemoveItem(item.ItemObj);
            _inventory.Save();
        }
    }
}
