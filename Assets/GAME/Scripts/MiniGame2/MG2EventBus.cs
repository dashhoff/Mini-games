using System;
using UnityEngine;

public class MG2EventBus : MonoBehaviour
{
    public static event Action OnVictory;

    public static void InvokeVictory()
    {
        Debug.Log("MG2 Victory!");
        OnVictory?.Invoke();
    }
}
