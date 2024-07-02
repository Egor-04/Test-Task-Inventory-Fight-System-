using UnityEngine;

public class Inventory : MonoBehaviour
{
    public DraggedItem DraggedItemPrefab;
    [SerializeField] private PopUpInfo _popUpPanel;
    [SerializeField] private ItemDataBase _allItemsData;
    [SerializeField] private Cell[] _inventoryCells;
    private int j = 0;

    private void Start()
    {
        _allItemsData = FindObjectOfType<ItemDataBase>();
        AddStartItemsToInventory();
    }

    public void OnEnable()
    {
        EventManager.onCellClicked += OpenPopUpPanel;
    }

    public void OnDisable()
    {
        EventManager.onCellClicked -= OpenPopUpPanel;
    }

    private void OpenPopUpPanel(Cell cell, Item item)
    {
        _popUpPanel.SetInfo(cell, item);
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

    public void AddRandomItem()
    {
        for (int j = 0; j < _inventoryCells.Length; j++)
        {
            if (_inventoryCells[j] != null && _inventoryCells[j].GetItemInCell() == null)
            {
                Item foundItem = _allItemsData.FindItem(Random.Range(1, _allItemsData.GetItemdataLength() + 1));
                _inventoryCells[j].SetCellParameters(foundItem);
                break;
            }
        }
    }

    public Cell FindItem(int itemID)
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            if (_inventoryCells[i] != null)
            {
                if (_inventoryCells[i].GetItemInCell() != null && _inventoryCells[i].GetItemInCell().ID == itemID)
                {
                    return _inventoryCells[i];
                }
            }
        }
        return null;
    }
}