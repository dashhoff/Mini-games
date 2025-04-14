using System;
using UnityEngine;

public class MG1EventBus : MonoBehaviour
{
    public static event Action OnVictory;

    public static void InvokeVictory()
    {
        Debug.Log("MG1 Victory!");
        OnVictory?.Invoke();
    }
}
