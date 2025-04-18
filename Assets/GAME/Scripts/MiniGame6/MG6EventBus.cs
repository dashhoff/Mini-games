using System;
using UnityEngine;

public class MG6EventBus : MonoBehaviour
{
    public static event Action OnVictory;
    public static event Action OnDefeat;

    public static event Action OnPause;
    public static event Action OnUnPause;

    public static event Action OnCorrect;
    public static event Action OnWrong;

    public static void InvokeVictory()
    {
        Debug.Log("MG6 Victory!");
        OnVictory?.Invoke();
    }

    public static void InvokeDefeat()
    {
        Debug.Log("MG6 Defeat!");
        OnDefeat?.Invoke();
    }

    public static void InvokePause()
    {
        Debug.Log("MG6 Pause!");
        OnPause?.Invoke();
    }

    public static void InvokeUnPause()
    {
        Debug.Log("MG6 UnPause!");
        OnUnPause?.Invoke();
    }

    public static void InvokeCorrect()
    {
        Debug.Log("MG6 Correct!");
        OnCorrect?.Invoke();
    }

    public static void InvokeWrong()
    {
        Debug.Log("MG6 Wrong!");
        OnWrong?.Invoke();
    }
}
