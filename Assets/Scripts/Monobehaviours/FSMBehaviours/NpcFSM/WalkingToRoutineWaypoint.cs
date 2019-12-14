using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingToRoutineWaypoint : NPCBaseFSM
{
    private Routine routine;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        routine = npcScript.routine;

        routine.UpdateCurrentWaypointByIndex(routine.currentWaypointIndex);
        npcScript.SetTarget(routine.CurrentWaypoint);

        routine.CurrentWaypoint.ResetWaypoint();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npcScript.SetTarget(routine.CurrentWaypoint);

        if (!npcScript.ReachedCurrentWaypoint())
            npcScript.GoToCurrentWaypoint();
        else
            animator.SetTrigger("ReachedWaypoint");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.ResetTrigger("ReachedWaypoint");
    }
}