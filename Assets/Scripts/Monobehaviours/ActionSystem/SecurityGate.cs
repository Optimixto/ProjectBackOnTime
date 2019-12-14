using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGate : MonoBehaviour
{
    public Waypoint[] waypoints;
    public bool areConditionsMet;
    public GameObject laserBeams;

    private void FixedUpdate()
    {
        areConditionsMet = UpdateConditionsMet();
        if (areConditionsMet)
            laserBeams.SetActive(false);
        else
            laserBeams.SetActive(true);
    }

    private bool UpdateConditionsMet()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (!waypoints[i].AllActionsDone)
                return false;
        }

        return true;
    }
}