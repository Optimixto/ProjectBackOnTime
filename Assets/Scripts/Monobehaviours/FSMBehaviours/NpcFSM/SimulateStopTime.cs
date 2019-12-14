using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateStopTime : NPCBaseFSM
{
    private PlayerDetector playerDetector;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerDetector = npcScript.playerDetector;
        playerDetector.enabled = false;
        npcScript.StopMovement();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerDetector.enabled = true;
    }
}