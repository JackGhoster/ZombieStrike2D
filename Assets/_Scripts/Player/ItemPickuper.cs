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
            EventManager.Instance.ItemPicked();
            _inventory.AddItem(item.ItemObj, 1);
            _inventory.Save();
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
    }
    private void OnApplicationQuit()
    {
        _inventory.Slots.Clear();
    }
}
