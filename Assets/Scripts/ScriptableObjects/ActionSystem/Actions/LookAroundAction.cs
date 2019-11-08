using UnityEngine;

public class LookAroundAction : Action
{
    public Transform npcAvatarTransform;
    public Transform myWaypointTransform;
    [Range(20f, 90f)]
    public float deltaAngle = 45f; // Amount to move left and right from the start point
    [Range(0.5f, 5f)]
    public float rotationSpeed = 1.5f;
    public int totalLookingLoops = 1;

    private Vector3 initialRotationForward;
    private Vector3 currentRotationForward;
    private float sinCounter;
    private int timesLookedAround;

    protected override void SpecificInit()
    {
        initialRotationForward = myWaypointTransform.forward;
        currentRotationForward = initialRotationForward;

        timesLookedAround = 0;
        sinCounter = 0;
    }

    protected override bool PerformAction()
    {
        currentRotationForward = Quaternion.Euler(0f, deltaAngle * Mathf.Sin(sinCounter), 0f) * initialRotationForward;
        npcAvatarTransform.forward = currentRotationForward;

        sinCounter += 0.01f*rotationSpeed;
        
        if (PassedInitialRotation())
        {
            if (timesLookedAround >= totalLookingLoops)
            {
                return true;
            }
            else
                timesLookedAround++;
        }

        return false;
    }

    private bool PassedInitialRotation()
    {
        if (Mathf.Abs(Mathf.Sin(sinCounter)) <= Mathf.Abs(Mathf.Sin(sinCounter - 0.01f * rotationSpeed)))
            if (Mathf.Abs(Mathf.Sin(sinCounter)) <= Mathf.Abs(Mathf.Sin(sinCounter + 0.01f * rotationSpeed)))
                return true;

        return false;
    }
}
