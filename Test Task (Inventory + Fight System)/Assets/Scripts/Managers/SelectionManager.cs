using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }

    private ISelectable currentSelected;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SelectItem(ISelectable selectable)
    {
        if (currentSelected != null)
        {
            currentSelected.Deselect();
        }
        else
        {
            currentSelected = selectable;
            currentSelected.Select();
        }
    }

    public ISelectable GetCurrentSelectedItem()
    {
        return currentSelected;
    }
}
