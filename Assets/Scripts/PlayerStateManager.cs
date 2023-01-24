using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateManager : MonoBehaviour
{
    /// <summary>
    /// State Manager that I use as a component for Player.
    /// Sets Idling State as the first state.
    /// </summary>
    public Animator animator;
    public NavMeshAgent agent;

    private PlayerAbstractState _currentState;


    public PlayerIdlingState idlingState = new PlayerIdlingState();
    public PlayerWalkingState walkingState = new PlayerWalkingState();
    public PlayerShootingState shootingState = new PlayerShootingState();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = idlingState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    /// <summary>
    /// Public method to switch states to other states even within the concrete states.
    /// </summary>
    /// <param name="newState">Takes a state as a parameter.</param>
    public void SwitchState(PlayerAbstractState newState)
    {
        _currentState = newState;
        newState.EnterState(this);
    }


}
