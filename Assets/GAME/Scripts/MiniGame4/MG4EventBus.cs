using System;
using UnityEngine;

public class MG4EventBus : MonoBehaviour
{
    public static event Action OnVictory;
    public static event Action OnDefeat;

    public static event Action OnPause;
    public static event Action OnUnPause;

    public static event Action OnCorrect;
    public static event Action OnWrong;

    public static void InvokeVictory()
    {
        Debug.Log("MG4 Victory!");
        OnVictory?.Invoke();
    }

    public static void InvokeDefeat()
    {
        Debug.Log("MG4 Defeat!");
        OnDefeat?.Invoke();
    }

    public static void InvokePause()
    {
        Debug.Log("MG4 Pause!");
        OnPause?.Invoke();
    }

    public static void InvokeUnPause()
    {
        Debug.Log("MG4 UnPause!");
        OnUnPause?.Invoke();
    }

    public static void InvokeCorrect()
    {
        Debug.Log("MG4 Correct!");
        OnCorrect?.Invoke();
    }

    public static void InvokeWrong()
    {
        Debug.Log("MG4 Wrong!");
        OnWrong?.Invoke();
    }
}
