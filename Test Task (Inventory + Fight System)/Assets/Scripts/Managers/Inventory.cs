using UnityEngine;

public class Inventory : MonoBehaviour
{
    public DraggedItem DraggedItemPrefab;
    [SerializeField] private Cell[] _inventoryCells;
    [SerializeField] private ItemDataBase _allItemsData;

    private void Start()
    {
        _allItemsData = FindObjectOfType<ItemDataBase>();
        AddStartItemsToInventory();
    }

    private void AddStartItemsToInventory()
    {
        for (int i = 0; i < _allItemsData.GetItemdataLength(); i++)
        {
            Item foundItem = _allItemsData.FindItem(i+1);
            if (_inventoryCells[i].GetItemInCell() == null)
            {
                _inventoryCells[i].SetCellParameters(foundItem);
            }
        }
    }

    public Cell FindItem(int itemID)
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            if (_inventoryCells[i].GetItemInCell().ID == itemID)
            {
                return _inventoryCells[i];
            }
        }
        return null;
    }
}
