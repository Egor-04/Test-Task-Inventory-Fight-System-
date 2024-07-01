using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Cell[] _inventoryCells;

    private void AddKitStartInInventory()
    {
        
    }

    private void AddItem(int ID)
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            if (_inventoryCells[i].ItemInCell == null)
            {

            }
        }
    }

    public Item FindItem(int itemID)
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            if (_inventoryCells[i].ItemInCell.ID == itemID)
            {
                return _inventoryCells[i].ItemInCell;
            }
        }
        return null;
    }
}
