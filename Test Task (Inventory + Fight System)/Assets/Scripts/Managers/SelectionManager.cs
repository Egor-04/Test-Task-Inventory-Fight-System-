using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }
    [SerializeField] private int _selectedWeaponNow;
    [SerializeField] private SelectableWeapon _pistol, _rifle;

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

    public void SelectItem(int weaponID)
    {
        _pistol.SelectDeselect(false);
        _rifle.SelectDeselect(false);

        if (weaponID == 1)
        {
            _pistol.SelectDeselect(true);
            _selectedWeaponNow = weaponID;
        }
        else if (weaponID == 2)
        {
            _rifle.SelectDeselect(true);
            _selectedWeaponNow = weaponID;
        }
    }
}
