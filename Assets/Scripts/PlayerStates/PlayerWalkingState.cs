using UnityEngine;
using UnityEngine.AI;

public class PlayerWalkingState : PlayerAbstractState
{
    /// <summary>
    /// Check Player Abstract State for info
    /// </summary>
    private PlayerStateManager _context;
    private PlayerMovement _playerMovementComponent;
    public override void EnterState(PlayerStateManager player)
    {
        _playerMovementComponent = player.gameObject.GetComponent<PlayerMovement>();        
        _playerMovementComponent.enabled = true;
        _context = player;
        EventManager.current.OnWaypointReached += StopMoving;
    }

    public override void UpdateState(PlayerStateManager player)
    {        
    }

    public override void ExitState(PlayerStateManager player)
    {
        EventManager.current.OnWaypointReached -= StopMoving;
        _playerMovementComponent.enabled = false;
        player.SwitchState(player.shootingState);
    }

    private void StopMoving()
    {
        ExitState(_context);
    }

}
