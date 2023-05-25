[System.Serializable]
public class InventorySlot
{
    public ItemObject Item;
    public int Amount;
    public InventorySlot(ItemObject item, int amount)
    {
        this.Item = item;
        this.Amount = amount;
    }
    public void AddAmount(int value)
    {
        Amount += value;
    }

}