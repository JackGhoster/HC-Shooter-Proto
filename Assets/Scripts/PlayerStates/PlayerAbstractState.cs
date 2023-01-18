using UnityEngine;

public abstract class PlayerAbstractState
{
    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);

    public abstract void ExitState(PlayerStateManager player);

}