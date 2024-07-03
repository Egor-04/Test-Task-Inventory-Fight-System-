using UnityEngine;

public class Enemy : Health
{
    public int Damage { get; private set; } = 15;
    private int nextValue;
    private bool isDead;

    protected override void TakeDamageToHead(int damageValue)
    {
        _healthValue -= damageValue;
        UpdateVisualInfo();
    }
    protected override void TakeDamageToBody(int damageValue)
    {
        _healthValue -= damageValue;
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
        CheckEnemyHealth();
    }

    private void CheckEnemyHealth()
    {
        if (_healthValue <= 0)
        {
            EventManager.onEnemyDie?.Invoke();
            _healthValue = 0;
            isDead = true;
            UpdateVisualInfo();
        }
    }

    protected override void UpdateVisualInfo()
    {
        base.UpdateVisualInfo();
    }

    public bool IsDead() { return isDead; }
}