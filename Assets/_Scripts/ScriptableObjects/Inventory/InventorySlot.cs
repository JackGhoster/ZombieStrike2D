[System.Serializable]
public class InventorySlot
{
    public ItemObject Item;
    public int Amount;
    public int Id;
    public InventorySlot(int id, ItemObject item, int amount)
    {
        this.Id = id;
        this.Item = item;
        this.Amount = amount;
    }
    public void AddAmount(int value)
    {
        Amount += value;
    }
    public void RemoveAmount(int value)
    {
        Amount -= value;
    }

}