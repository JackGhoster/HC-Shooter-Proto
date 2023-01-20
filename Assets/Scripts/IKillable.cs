using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    public abstract int MaxHealthPoints();

    public abstract int LoseHealthPoints();

    public abstract void CheckHealthPoints();

}
