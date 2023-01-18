using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlingState : PlayerAbstractState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Hello");
    }

    public override void ExitState(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        CheckIfGameStarted();
        Debug.Log("I am Idling");
    }

    private void CheckIfGameStarted()
    {
        Debug.Log("Game Started");
    }

}
