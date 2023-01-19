using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints;
    private int _waypointIndex = 0;
    
    private EventManager _eventManager;

    public Transform currentWaypoint;

    public static GameManager current;


    private void Awake()
    {
        current = this;
        currentWaypoint = _waypoints[0];
    }

    private void Start()
    {
        _eventManager = EventManager.current;
        _eventManager.OnShootingEnded += WaypointItterator;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
           _eventManager.StartGame();
        }
    }

    public void WaypointItterator()
    {
        _waypointIndex++;
        currentWaypoint = _waypoints[_waypointIndex];
        Debug.Log($"Current Waypoint {currentWaypoint}");
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        _eventManager.OnShootingEnded -= WaypointItterator;
    }
}
