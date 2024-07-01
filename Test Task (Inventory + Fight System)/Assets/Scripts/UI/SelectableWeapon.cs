using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableWeapon : MonoBehaviour, ISelectable, IPointerClickHandler
{
    [SerializeField] private Image _mainImage;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _notSelectedSprite;
    [SerializeField] private Weapon _weapon;

    private bool isSelected;

    private void Start()
    {
        _mainImage = GetComponent<Image>();
    }

    public void Select()
    {
        isSelected = true;
        UpdateVisualState();
    }

    public void Deselect()
    {
        isSelected = false;
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        isSelected = true ? _mainImage.sprite = _selectedSprite : _mainImage.sprite = _notSelectedSprite;
    }

    public void OnClick()
    {
        SelectionManager.Instance.SelectItem(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public Weapon GetWeapon()
    {
        return _weapon;
    }

    public void SetWeapon(Weapon newWeapon)
    {
        _weapon = newWeapon;
    }
}