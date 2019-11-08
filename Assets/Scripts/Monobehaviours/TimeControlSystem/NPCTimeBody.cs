using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTimeBody : TimeBody
{
    protected new List<NPCStateInTime> StatesInTime;
    protected new NPCStateInTime CurrentStateInTime;
    NPC npcScript;

    protected override void Start()
    {
        npcScript = transform.GetComponentInChildren<NPC>();

        StatesInTime = new List<NPCStateInTime>();
        rb = GetComponent<Rigidbody>();
    }

    protected override void Rewind()
    {
        if (StatesInTime.Count > 0)
        {
            npcScript.animator.SetBool("TimeRewinding", true);
            CurrentStateInTime = StatesInTime[0];

            transform.position = CurrentStateInTime.position;
            transform.rotation = CurrentStateInTime.rotation;
            npcScript.routine.currentWaypointIndex = CurrentStateInTime.routineWaypointIndex;
            npcScript.playerDetector.SetStatusTimer(CurrentStateInTime.statusTimer);
            StatesInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    protected override void Record()
    {
        if(StatesInTime.Count > Mathf.Round(recordTime/Time.fixedDeltaTime))
        {
            Debug.Log(StatesInTime.Count);
            StatesInTime.RemoveAt(StatesInTime.Count-1);
        }
        
        StatesInTime.Insert(0, new NPCStateInTime(transform.position, transform.rotation, npcScript.routine.currentWaypointIndex, npcScript.playerDetector.StatusTimer));
    }

    protected override void StartRewind()
    {
         isRewinding = true;
         rb.isKinematic = true;
    }

    protected override void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        npcScript.animator.SetBool("TimeRewinding", false);
    }
}
