using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public PlayerData PlayerData { get; set; }
    public EnemyData EnemyData { get; set; }
    public List<ItemData> ItemDatas { get; set; }
}