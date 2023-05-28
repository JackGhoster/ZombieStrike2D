using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private InventoryObject _inventory;
    [SerializeField]
    private Button _inventoryButton;
    [SerializeField]
    private Image _inventoryUI;
    private bool _inventoryVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        _inventory.Load();

        _inventoryButton.onClick.AddListener(ShowInventory);
    }

    private void ShowInventory()
    {
        if(_inventoryVisible) _inventoryUI.gameObject.SetActive(false);

        else _inventoryUI.gameObject.SetActive(true);
        _inventoryVisible = !_inventoryVisible;
    }
}
