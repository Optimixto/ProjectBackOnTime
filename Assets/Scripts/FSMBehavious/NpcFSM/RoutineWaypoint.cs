using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineWaypoint : NPCBaseFSM
{
    private Routine routine;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        routine = npcScript.routine;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        routine.PerformWaypointUntilDone(animator);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AllActionsDone");
    }
}
