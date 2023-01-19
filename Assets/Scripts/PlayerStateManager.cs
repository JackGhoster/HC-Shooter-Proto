using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateManager : MonoBehaviour
{
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

    public void SwitchState(PlayerAbstractState newState)
    {
        _currentState = newState;
        newState.EnterState(this);
    }


}
