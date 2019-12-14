using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitHereAction : Action
{
    [SerializeField]
    private float totalWaitTime = 1f;

    private float timeWaited;

    protected override void SpecificInit()
    {
        timeWaited = 0f;
    }

    private void IncrementTimeWaited()
    {
        timeWaited += Time.deltaTime;
    }

    protected override bool PerformAction()
    {
        if (timeWaited >= totalWaitTime)
        {
            return true;
        }
        else
        {
            IncrementTimeWaited();
            return false;
        }
    }
}