using System;
using UnityEngine;

public class MG3EventBus : MonoBehaviour
{
    public static event Action OnVictory;
    public static event Action OnDefeat;

    public static event Action OnPause;
    public static event Action OnUnPause;

    public static event Action OnCorrectPair;
    public static event Action OnWrongPair;

    public static void InvokeVictory()
    {
        Debug.Log("MG3 Victory!");
        OnVictory?.Invoke();
    }

    public static void InvokeDefeat()
    {
        Debug.Log("MG3 Defeat!");
        OnDefeat?.Invoke();
    }

    public static void InvokePause()
    {
        Debug.Log("MG3 Pause!");
        OnPause?.Invoke();
    }

    public static void InvokeUnPause()
    {
        Debug.Log("MG3 UnPause!");
        OnUnPause?.Invoke();
    }

    public static void InvokeCorrectPair()
    {
        Debug.Log("MG3 CorrectPair!");
        OnCorrectPair?.Invoke();
    }

    public static void InvokeWrongPair()
    {
        Debug.Log("MG3 Wrong!");
        OnWrongPair?.Invoke();
    }
}
