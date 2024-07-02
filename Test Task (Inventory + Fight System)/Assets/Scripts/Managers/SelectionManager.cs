using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }
    [SerializeField] private int _selectedWeaponNow;
    [SerializeField] private SelectableWeapon _pistolUI, _rifleUI;
    [SerializeField] private Weapon _pistol, _rifle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SelectItem(1);
    }

    public Weapon GetSelectedWeapon() { return _selectedWeaponNow == 1 ? _pistol : _rifle; }

    public void SelectItem(int weaponID)
    {
        _pistolUI.SelectDeselect(false);
        _rifleUI.SelectDeselect(false);

        if (weaponID == 1)
        {
            _pistolUI.SelectDeselect(true);
            _selectedWeaponNow = weaponID;
        }
        else if (weaponID == 2)
        {
            _rifleUI.SelectDeselect(true);
            _selectedWeaponNow = weaponID;
        }
    }
}