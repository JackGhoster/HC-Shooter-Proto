using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Manages general game logic such as starting the game at the beginning and etc
    /// </summary>
   
    [SerializeField]
    private List<Transform> _waypoints;
    private int _waypointIndex = 0;
    
    private EventManager _eventManager;
    private TouchManager _touchManager;

    public Transform currentWaypoint;
    public int currentEnemyCluster = 0;

    public static GameManager current;

    

    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        currentWaypoint = _waypoints[0];
        _touchManager = GameObject.FindGameObjectWithTag("TouchManager").GetComponent<TouchManager>();

    }

    private void Start()
    {
        _eventManager = EventManager.current;
        _eventManager.OnShootingEnded += WaypointItterator;
        _eventManager.OnScreenPressed += StartGame;
    }

    private void Update()
    {
    }

    public void WaypointItterator()
    {
        currentEnemyCluster++;        
        _waypointIndex++;
        currentWaypoint = _waypoints[_waypointIndex];
        Debug.Log($"Current Waypoint {currentWaypoint}");
    }

    private void StartGame()
    {
        _eventManager.StartGame();
    }


    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        _eventManager.OnShootingEnded -= WaypointItterator;
        _eventManager.OnScreenPressed -= StartGame;
    }
}
