using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypoint : Waypoint
{
    public CaughtDetector caughtDetector;
    public TimeBody timeBody;
    public GameObject actionGameObject;

    [HideInInspector]
    public bool isInteracting;

    private Transform playerTransform;
    private PlayerInputActions inputAction;

    protected override void Awake()
    {
        inputAction = new PlayerInputActions();
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerGameObject.transform;
        caughtDetector = playerGameObject.GetComponentInChildren<CaughtDetector>();
        UpdateActionLocation(actionGameObject.transform);
    }

    private void Update()
    {
        if (AllActionsDone)
        {
            isInteracting = false;
        }
        else if (isInteracting && !(timeBody.isRewinding || timeBody.isTimeStopped))
        {
            Act();
            ForceLookAt();
        }
        else if (!isInteracting && !AllActionsDone)
            ResetWaypoint();
    }

    private void ForceLookAt()
    {
        Vector3 lookDirection = new Vector3(actionLocation.x, playerTransform.position.y, actionLocation.z);
        playerTransform.LookAt(lookDirection, Vector3.up);
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}