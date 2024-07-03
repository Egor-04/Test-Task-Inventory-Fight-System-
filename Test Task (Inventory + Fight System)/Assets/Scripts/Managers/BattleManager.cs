using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private int _currentMove = 0;

    [Header("Selected Weapon")]
    [SerializeField] private SelectionManager _selectionManager;

    [Header("Enemy Move Options")]
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    public void DoMove()
    {
        if (_enemy.IsDead() == true || _player.IsDead() == true)
        {
            return;
        }

        if (_currentMove == 0)
        {
            _currentMove = 1;
            _enemy.TakeDamage(_selectionManager.GetSelectedWeapon().Shot());
        }
        else
        {
            _currentMove = 0;
            _player.TakeDamage(_enemy.Damage);
        }

        EventManager.onGameWasChanged?.Invoke();
    }
}
