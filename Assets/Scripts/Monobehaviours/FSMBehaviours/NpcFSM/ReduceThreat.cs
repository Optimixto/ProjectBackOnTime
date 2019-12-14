using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceThreat : NPCBaseFSM
{
    private PlayerDetector playerDetector;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        playerDetector = npcScript.playerDetector;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerDetector.StatusTimer > 0)
            playerDetector.ReduceCurrentStatusTimer();

        playerDetector.UpdateAwarenessColor();
    }
}