using UnityEngine;

public class Player : Health
{
    [SerializeField] private Cell _headEquipment, _bodyequipment;
    private int nextValue;
    private bool isDead;

    private void OnEnable()
    {
        EventManager.onPlayerHeal += AddHealth;
    }

    private void OnDisable()
    {
        EventManager.onPlayerHeal -= AddHealth;
    }

    public bool IsDead() { return isDead; }

    public override int GetHealth()
    {
        return base.GetHealth();
    }

    protected override void TakeDamageToHead(int damageValue)
    {
        if (_headEquipment.GetItemInCell() is Equipment headArmor)
        {
            _healthValue -= Mathf.Max(0, damageValue - headArmor.ArmorPoints);
            _healthText.text = _healthValue.ToString();
            _healthBar.value = _healthValue;
        }
        else
        {
            _healthValue -= damageValue;
            _healthText.text = _healthValue.ToString();
            _healthBar.value = _healthValue;
        }
        CheckPlayerHealth();
    }

    protected override void TakeDamageToBody(int damageValue)
    {
        if (_bodyequipment.GetItemInCell() is Equipment bodyArmor)
        {
            _healthValue -= Mathf.Max(0, damageValue - bodyArmor.ArmorPoints);
            _healthBar.value = _healthValue;
            _healthText.text = _healthValue.ToString();
        }
        else
        {
            _healthValue -= damageValue;
            _healthBar.value = _healthValue;
            _healthText.text = _healthValue.ToString();
        }

        CheckPlayerHealth();
    }

    public void AddHealth(int healPoints)
    {
        _healthValue += healPoints;

        if (_healthValue >= 100)
        {
            _healthValue = 100;
        }

        UpdateVisualInfo();
    }

    public void TakeDamage(int damageValue)
    {
        if (nextValue == 0)
        {
            nextValue = 1;
            TakeDamageToHead(damageValue);
        }
        else
        {
            nextValue = 0;
            TakeDamageToBody(damageValue);
        }
    }

    private void CheckPlayerHealth()
    {
        if (_healthValue <= 0)
        {
            EventManager.onPlayerDie?.Invoke();
            _healthValue = 0;
            isDead = true;
            UpdateVisualInfo();
        }
    }

    protected override void UpdateVisualInfo()
    {
        base.UpdateVisualInfo();
    }

    public void SetPlayerData(PlayerData playerData)
    {
        _healthValue = playerData.Health;
        isDead = playerData.IsDead;
        UpdateVisualInfo();
    }

    public PlayerData GetPlayerData()
    {
        return new PlayerData()
        {
            Health = _healthValue,
            IsDead = isDead
        };
    }
}
