using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservePlayer : NPCBaseFSM
{
    private PlayerDetector playerDetector;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerDetector = npcScript.playerDetector;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npcScript.RotateTowardsWaypoint(npcScript.LastKnownPositionWaypoint);
    }
}