using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerStateInTime : StateInTime
{
    public bool areConditionsMet;

    public ComputerStateInTime(bool areConditionsMet)
    {
        this.areConditionsMet = areConditionsMet;
    }

    public void ApplyState(PlayerWaypoint playerWaypoint)
    {
        if (!areConditionsMet)
            playerWaypoint.ResetWaypoint();
    }
}