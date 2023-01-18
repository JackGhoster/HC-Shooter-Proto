using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerAbstractState _currentState;
    public PlayerIdlingState IdlingState = new PlayerIdlingState();
    public PlayerWalkingState WalkingState = new PlayerWalkingState();
    public PlayerShootingState ShootingState = new PlayerShootingState();

    // Start is called before the first frame update
    void Start()
    {
        _currentState = IdlingState;
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
