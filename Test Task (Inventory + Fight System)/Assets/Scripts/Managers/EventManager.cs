using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action onEnemyDie;
    public static Action onPlayerDie;
    public static Action<Cell, Item> onCellClicked;
}
