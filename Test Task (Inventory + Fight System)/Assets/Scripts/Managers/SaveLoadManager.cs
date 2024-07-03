using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Cell[] _cells;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _enemy = FindAnyObjectByType<Enemy>();
        _inventory = FindAnyObjectByType<Inventory>();
    }

    private void Start()
    {
        LoadGame();
    }

    private void OnEnable()
    {
        EventManager.onGameWasChanged += SaveGame;
    }

    private void OnDisable()
    {
        EventManager.onGameWasChanged -= SaveGame;
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            PlayerData = _player.GetPlayerData(),
            EnemyData = _enemy.GetEnemyData(),
            ItemDatas = new List<ItemData>(_cells.Length)
        };

        for (int i = 0; i < _cells.Length; i++)
        {
            if (_cells[i].GetItemInCell() != null)
            {
                saveData.ItemDatas.Add(new ItemData());
                saveData.ItemDatas[saveData.ItemDatas.Count - 1].SetItemInfo(_cells[i]);
            }
        }

        SaveSystem.Save(saveData);
    }

    public void LoadGame()
    {
        SaveData saveData = SaveSystem.Load();
        if (saveData != null)
        {
            _player.SetPlayerData(saveData.PlayerData);
            _enemy.SetEnemyData(saveData.EnemyData);

            for (int i = 0; i < saveData.ItemDatas.Count; i++)
            {
                _inventory.AddCustomItem(saveData.ItemDatas[i].ID, saveData.ItemDatas[i].CurrentQuantity);
            }
        }
    }
}
