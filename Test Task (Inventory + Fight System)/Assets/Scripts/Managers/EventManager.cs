using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action onEnemyDie;
    public static Action onPlayerDie;
    public static Action<int> onBuyAmmo;
    public static Action<int> onPlayerHeal;
    public static Action<Cell, Item> onCellClicked;
}
