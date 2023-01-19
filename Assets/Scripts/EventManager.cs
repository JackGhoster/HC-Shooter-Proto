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
    public event Action OnShootingEnded;

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

    public void ShootingEnded()
    {
        if(OnShootingEnded != null)
        {
            OnShootingEnded();
        }
    }
}
