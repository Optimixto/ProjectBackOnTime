using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigate : NPCBaseFSM
{
    private PlayerDetector playerDetector;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        npcScript.LastKnownPositionWaypoint.ResetWaypoint();

        playerDetector = npcScript.playerDetector;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!npcScript.ReachedCurrentWaypoint())
            npcScript.GoToLastSeenPosition();

        if (npcScript.ArrivedAtWaypoint(npcScript.LastKnownPositionWaypoint))
            npcScript.LastKnownPositionWaypoint.Act();

        if (npcScript.LastKnownPositionWaypoint.AllActionsDone)
        {
            animator.SetBool("DoneInvestigating", true);
            npcScript.ChangeSpeed(playerDetector.awarenessStatuses.defaultMovSpeed);
        }
    }
}