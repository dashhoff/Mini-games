using System;
using UnityEngine;

public class MG5EventBus : MonoBehaviour
{
    public static event Action OnStartGame;

    public static event Action OnVictory;
    public static event Action OnDefeat;

    public static event Action OnPause;
    public static event Action OnUnPause;

    public static event Action OnCorrect;
    public static event Action OnWrong;

    public static void InvokeStartGame()
    {
        Debug.Log("MG5 StartGame!");
        OnStartGame?.Invoke();
    }

    public static void InvokeVictory()
    {
        Debug.Log("MG5 Victory!");
        OnVictory?.Invoke();
    }

    public static void InvokeDefeat()
    {
        Debug.Log("MG5 Defeat!");
        OnDefeat?.Invoke();
    }

    public static void InvokePause()
    {
        Debug.Log("MG5 Pause!");
        OnPause?.Invoke();
    }

    public static void InvokeUnPause()
    {
        Debug.Log("MG5 UnPause!");
        OnUnPause?.Invoke();
    }

    public static void InvokeCorrect()
    {
        Debug.Log("MG5 Correct!");
        OnCorrect?.Invoke();
    }

    public static void InvokeWrong()
    {
        Debug.Log("MG5 Wrong!");
        OnWrong?.Invoke();
    }
}
