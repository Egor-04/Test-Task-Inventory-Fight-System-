public class PlayerData
{
    public int Health;
    public bool IsDead;

    public void SetPlayerData(Player player)
    {
        this.Health = player.GetHealth();
        this.IsDead = player.IsDead();
    }

    public PlayerData GetPlayerData()
    {
        return this;
    }
}