using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : MonoBehaviour
{
    [SerializeField]
    private ItemDatabaseObject _database;
    private ItemObject randomItem;

    private void Start()
    {
        randomItem = _database.GetItem[Random.Range(0, _database.Items.Length)];
    }
    private void DropLoot()
    {
        var drop = randomItem;
        Instantiate(drop.WorldInstance,transform.position, Quaternion.identity);
    }
    private void OnDisable()
    {
        DropLoot();     
    }
}
