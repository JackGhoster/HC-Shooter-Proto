using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingState : PlayerAbstractState
{
    private PlayerStateManager _context;
    private PlayerShooting _playerShootingComponent;


    public override void EnterState(PlayerStateManager player)
    {
        _context = player;
        _playerShootingComponent = player.gameObject.GetComponent<PlayerShooting>();
        _playerShootingComponent.enabled = true;
        EventManager.current.OnShootingEnded += StopShooting;

    }
    public override void UpdateState(PlayerStateManager player)
    {
    }

    public override void ExitState(PlayerStateManager player)
    {
        EventManager.current.OnShootingEnded -= StopShooting;
        _playerShootingComponent.enabled = false;
        Debug.Log(player);
        player.SwitchState(player.walkingState);       
    }

    private void StopShooting()
    {
        ExitState(_context);
    }

}
