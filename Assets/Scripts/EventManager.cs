using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnGameStarted;
    public event Action OnWaypointReached;
    public event Action OnScreenPressed;
    public event Action OnShootingEnded;
    public event Action OnKill;
    public event Action OnWin;

    public void StartGame()
    {
        if(OnGameStarted != null)
        {
            OnGameStarted();
        }
    }

    public void WaypointReached()
    {
        if(OnWaypointReached != null)
        {
            OnWaypointReached();
            Debug.Log("Waypoint Reached");
        }
    }

    public void ScreenPressed()
    {
        if (OnScreenPressed != null)
        {
            OnScreenPressed();
        }
    }

    public void ShootingEnded()
    {
        if(OnShootingEnded != null)
        {
            OnShootingEnded();
        }
    }

    public void Killed()
    {
        if (OnKill != null)
        {
            OnKill();
        }
    }

    public void Win()
    {
        if(OnWin != null)
        {
            OnWin();
        }
    }
}
