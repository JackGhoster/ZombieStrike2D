using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string SavePath;
    private ItemDatabaseObject _database;
    public List<InventorySlot> Slots = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        _database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/ItemDatabase.asset",typeof(ItemDatabaseObject));
#else
        _database = Resources.Load<ItemDatabaseObject>("ItemDatabase");
#endif
    }

    public void AddItem(ItemObject item, int amount)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Item == item)
            {
                Slots[i].AddAmount(amount);
                return;
            }
        }
        Slots.Add(new InventorySlot(_database.GetId[item],item, amount));
    }
    public void RemoveItem(ItemObject item)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Item == item)
            {
                if (Slots[i].Amount > 1)
                {
                    Slots[i].RemoveAmount(1);
                    return;
                }
                else
                {
                    Slots.RemoveAt(i);
                }
            }
        }

    }
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, SavePath));
        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, SavePath)))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, SavePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(binaryFormatter.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].Item = _database.GetItem[Slots[i].Id];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}

