using UnityEngine;

 public enum ItemType
{
    Gun,
    Armor,
    Ammo
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject Graphic;
    public GameObject WorldInstance;
    public ItemType Type;
    [TextArea(10,15)]
    public string Description;
}
