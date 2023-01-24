using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Behavior of the player that defines Movement logic of the player.
    /// Component should be disabled as default.
    /// Can be set enabled only upon entering Walking State.
    /// </summary>
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private NavMeshAgent _agent;

    private GameManager _gameManager;
    private EventManager _eventManager;

    private Transform _currentWaypoint;
    private float _remainingDistance = 100;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        
    }

    // Start is called before the first frame update
    void Start()
    {

        _eventManager = EventManager.current;

        //setting the initial destination
        _gameManager = GameManager.current;
        _currentWaypoint = _gameManager.currentWaypoint;

        //SwitchDestination(_agent, _currentWaypoint);

        _animator.SetBool("Walking", true);
    }

    private void Update()
    {
        Invoke("NearDestination", 0.5f);
    }



    private void SwitchDestination(NavMeshAgent agent, Transform destination)
    {
        Debug.Log(destination);
        agent.SetDestination(destination.position);
    }

    private void NearDestination()
    {
        _currentWaypoint = _gameManager.currentWaypoint;
        var howNear = 2.2f;
        if (CalculateDistance() < howNear)
        {          
            _eventManager.WaypointReached();
        }
    }

    public float CalculateDistance()
    {
        _remainingDistance = _agent.remainingDistance;
        return _remainingDistance;
    }


    private void OnEnable()
    {
        _animator.SetBool("Walking", true);
        StartCoroutine(GMCoroutine());        
    }

    private void OnDisable()
    {
        _animator.SetBool("Walking", false);
    }

    IEnumerator GMCoroutine()
    {        
        yield return new WaitForSeconds(0.25f);
        _currentWaypoint = _gameManager.currentWaypoint;
        SwitchDestination(_agent, _currentWaypoint);        
    }
}
