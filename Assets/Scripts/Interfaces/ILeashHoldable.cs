using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILeashHoldable
{
    /// <summary>
    /// Every ILeashHoldable shoul have an anchor
    /// </summary>
    /// <returns>the anchor of the LeashHoldable</returns>
    public abstract Leashanchor getLeashanchor();

    /// <summary>
    /// turns off the anchor, so that it isn't able to hold the leash anymore
    /// </summary>
    public abstract void TurnOffLeashAnchor();

    /// <summary>
    /// turns on the anchor, so that it is able to hold the anchor, again
    /// </summary>
    public abstract void TurnOnLeashAnchor();
}
