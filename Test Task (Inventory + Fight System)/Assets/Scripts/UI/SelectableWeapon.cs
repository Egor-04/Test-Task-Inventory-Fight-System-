using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableWeapon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _id;
    [SerializeField] private Image _mainImage;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _deselectedSprite;

    private bool isSelected;

    private void Awake()
    {
        _mainImage = GetComponent<Image>();
    }

    public bool GetState() { return isSelected ; }

    private void UpdateVisualState()
    {
        _mainImage.sprite = isSelected ? _selectedSprite : _deselectedSprite;
    }

    public void OnClick()
    {
        SelectionManager.Instance.SelectItem(_id);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public void SelectDeselect(bool state)
    {
        isSelected = state;
        UpdateVisualState();
    }
}