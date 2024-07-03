public class ItemData
{
    public int ID;
    public string Name;
    public int CurrentQuantity;

    public void SetItemInfo(Cell cell)
    {
        Item item = cell.GetItemInCell();
        this.ID = item.ID;
        this.Name = item.Name;
        this.CurrentQuantity = cell.GetQuantity();
    }
}
