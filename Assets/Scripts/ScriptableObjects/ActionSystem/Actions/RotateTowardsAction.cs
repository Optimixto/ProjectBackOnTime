using UnityEngine;

public class RotateTowardsAction : Action
{
    public Transform npcAvatarTransform;
    public Transform waypointTransform;

    private NPC npcScript;

    protected override void SpecificInit()
    {
        if (npcAvatarTransform != null)
        {
            npcScript = npcAvatarTransform.GetComponent<NPC>();

            if (npcScript == null)
            {
                Debug.LogError("Missing NPC script on " + npcAvatarTransform.name);
            }
        }
    }

    protected override bool PerformAction()
    {
        if (CheckIfAlreadyFacing())
            return true;
        else
        {
            npcScript.RotateTowardsDirection(waypointTransform.forward);

            return false;
        }
    }

    private bool CheckIfAlreadyFacing()
    {
        if (Vector3.Dot(npcAvatarTransform.forward.normalized, waypointTransform.forward.normalized) >= 0.999)
            return true;

        return false;
    }
}