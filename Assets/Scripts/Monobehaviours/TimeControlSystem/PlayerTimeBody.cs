using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeBody : TimeBody
{
    protected new List<StateInTimeTransform> StatesInTime;
    protected new StateInTimeTransform CurrentStateInTime;

    public Collider caughtDetectorCollider;
    public float timeSlowIncreaseDeterrent = 2f;

    private CharacterController characterController;
    private PlayerMovement playerMovementScript;

    protected override void Start()
    {
        StatesInTime = new List<StateInTimeTransform>();

        characterController = GetComponent<CharacterController>();
        playerMovementScript = GetComponent<PlayerMovement>();

        timeStopTimer = 0f;
    }

    public float CurrentRewindTimePercentage()
    {
        float currentPercentage = (StatesInTime.Count / recordTime) / 50;
        return currentPercentage;
    }

    public float CurrentStopTimePercentage()
    {
        float currentPercentage = (timeStopTimer / timeStopMax);
        return currentPercentage;
    }

    protected override void Rewind()
    {
        if (StatesInTime.Count > 0)
        {
            CurrentStateInTime = StatesInTime[0];

            CurrentStateInTime.ApplyState(transform);

            StatesInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    protected override void Record()
    {
        if (StatesInTime.Count >= Mathf.Round(recordTime / Time.fixedDeltaTime))
            StatesInTime.RemoveAt(StatesInTime.Count - 1);

        StatesInTime.Insert(0, new StateInTimeTransform(transform.position, transform.rotation));
    }

    protected override void StartRewind()
    {
        base.StartRewind();

        isRewinding = true;

        characterController.enabled = false;
        playerMovementScript.enabled = false;
    }

    protected override void StopRewind()
    {
        isRewinding = false;

        characterController.enabled = true;
        playerMovementScript.enabled = true;
    }

    protected override void StopTime()
    {
        isTimeStopped = true;
        caughtDetectorCollider.enabled = false;
        if (timeStopTimer > 0)
            timeStopTimer -= Time.fixedDeltaTime;
        else
            timeStopTimer = 0;
    }

    protected override void ResumeTime()
    {
        isTimeStopped = false;
        caughtDetectorCollider.enabled = true;

        if (inputAction.TimePowersControls.StopTime.ReadValue<float>() == 0)
        {
            if (timeStopTimer < timeStopMax)
                timeStopTimer += Time.fixedDeltaTime / timeSlowIncreaseDeterrent;
            else
                timeStopTimer = timeStopMax;
        }
    }
}