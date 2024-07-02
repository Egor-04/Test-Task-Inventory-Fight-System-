using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableWeapon : MonoBehaviour, ISelectable, IPointerClickHandler
{
    [SerializeField] private int _id;
    [SerializeField] private Image _mainImage;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _deselectedSprite;
    [SerializeField] private Weapon _weapon;

    private bool isSelected;

    private void Awake()
    {
        _mainImage = GetComponent<Image>();
    }

    public bool GetState() { return isSelected ; }

    public Weapon GetWeapon()
    {
        return _weapon;
    }

    public void SetWeapon(Weapon newWeapon)
    {
        _weapon = newWeapon;
    }

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