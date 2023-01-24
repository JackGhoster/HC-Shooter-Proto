using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerIdlingState : PlayerAbstractState
{
    /// <summary>
    /// Check Player Abstract State for info
    /// </summary>
    private PlayerStateManager _context;

    public override void EnterState(PlayerStateManager player)
    {
        EventManager.current.OnGameStarted += StopIdling;
        _context = player;
        Debug.Log("Entering Idling State");
    }

    public override void UpdateState(PlayerStateManager player)
    {
    }
    public override void ExitState(PlayerStateManager player)
    {
        EventManager.current.OnGameStarted -= StopIdling;
        Debug.Log("Switching to Walking State");
        player.SwitchState(player.walkingState);
    }

    private void StopIdling()
    {
        ExitState(_context);
    }

}
