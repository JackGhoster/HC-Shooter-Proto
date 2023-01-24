using UnityEngine;

public abstract class PlayerAbstractState
{
    /// <summary>
    /// Defines a base template for the states.
    /// I use states only to trigger events and turn on or turn off certain behaviors.
    /// States themselves don't contain information and methods of the behaviors.
    /// </summary>
    /// <param name="player">Takes a parameter of type PlayerStateManager</param>
    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);

    public abstract void ExitState(PlayerStateManager player);

}
