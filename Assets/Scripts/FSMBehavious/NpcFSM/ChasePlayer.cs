using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : NPCBaseFSM
{
    private PlayerDetector playerDetector;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerDetector = animator.transform.parent.GetComponentInChildren<PlayerDetector>();

        if(animator.GetBool("Alerted"))
            npcScript.ChangeSpeed(playerDetector.awarenessStatuses.AlertedMovSpeed);
        else
            npcScript.ChangeSpeed(playerDetector.awarenessStatuses.SuspiciousMovSpeed);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npcScript.GoToLastSeenPosition();
    }
}
