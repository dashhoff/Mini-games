using System;
using UnityEngine;

public class EventBus : MonoBehaviour
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
        Debug.Log("StartGame!");
        OnStartGame?.Invoke();
    }

    public static void InvokeVictory()
    {
        Debug.Log("Victory!");
        OnVictory?.Invoke();
    }

    public static void InvokeDefeat()
    {
        Debug.Log("Defeat!");
        OnDefeat?.Invoke();
    }

    public static void InvokePause()
    {
        Debug.Log("Pause!");
        OnPause?.Invoke();
    }

    public static void InvokeUnPause()
    {
        Debug.Log("UnPause!");
        OnUnPause?.Invoke();
    }

    public static void InvokeCorrect()
    {
        Debug.Log("Correct!");
        OnCorrect?.Invoke();
    }

    public static void InvokeWrong()
    {
        Debug.Log("Wrong!");
        OnWrong?.Invoke();
    }
}
