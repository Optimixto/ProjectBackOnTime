using UnityEngine;

public class PlayerTimeBody : TimeBody
{
    public Collider caughtDetectorCollider;
    public float timeSlowIncreaseDeterrent = 2f;

    private CharacterController characterController;
    private PlayerMovement playerMovementScript;

    protected override void Start()
    {
        base.Start();

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