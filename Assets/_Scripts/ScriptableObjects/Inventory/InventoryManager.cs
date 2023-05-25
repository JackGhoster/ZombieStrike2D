using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private InventoryObject _inventory;
    // Start is called before the first frame update
    void Start()
    {
        _inventory.Load();
    }


}
