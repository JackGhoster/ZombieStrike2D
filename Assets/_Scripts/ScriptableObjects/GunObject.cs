using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName = "New Gun Object", menuName="Inventory System/Items/Gun")]
public class GunObject : ItemObject
{
    public void Awake()
    {
        Type = ItemType.Gun;
    }
}
