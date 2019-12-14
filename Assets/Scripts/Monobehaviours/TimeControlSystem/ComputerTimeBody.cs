using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTimeBody : TimeBody
{
    public PlayerWaypoint myWaypoint;

    protected new List<ComputerStateInTime> StatesInTime;
    protected new ComputerStateInTime CurrentStateInTime;

    protected override void Start()
    {
        StatesInTime = new List<ComputerStateInTime>();
    }

    protected override void Rewind()
    {
        if (StatesInTime.Count > 0)
        {
            CurrentStateInTime = StatesInTime[0];

            CurrentStateInTime.ApplyState(myWaypoint);

            StatesInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    protected override void Record()
    {
        if (StatesInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            StatesInTime.RemoveAt(StatesInTime.Count - 1);

        StatesInTime.Insert(0, new ComputerStateInTime(myWaypoint.AllActionsDone));
    }
}