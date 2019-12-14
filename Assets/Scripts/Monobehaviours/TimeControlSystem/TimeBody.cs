using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public static float recordTime = 10f;

    [Range(0, 100)]
    public static float timeStopMax = 3f;

    protected static float timeStopTimer;

    protected virtual List<StateInTime> StatesInTime { get; private set; }

    protected virtual StateInTime CurrentStateInTime { get; private set; }

    public bool isRewinding = false;
    public bool isTimeStopped = false;

    protected PlayerInputActions inputAction;

    protected void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.TimePowersControls.RewindTime.started += ctx => StartRewind();
        inputAction.TimePowersControls.RewindTime.canceled += ctx => StopRewind();
    }

    protected virtual void Start()
    {
        StatesInTime = new List<StateInTime>();
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            ResumeTime();
            Rewind();
        }
        else if (inputAction.TimePowersControls.StopTime.ReadValue<float>() != 0 && !isRewinding && timeStopTimer > 0)
            StopTime();
        else
        {
            ResumeTime();
            Record();
        }
    }

    protected virtual void Rewind()
    {
        if (StatesInTime.Count > 0)
        {
            CurrentStateInTime = StatesInTime[0];

            CurrentStateInTime.ApplyState();

            StatesInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    protected virtual void Record()
    {
        if (StatesInTime.Count >= Mathf.Round(recordTime / Time.fixedDeltaTime))
            StatesInTime.RemoveAt(StatesInTime.Count - 1);

        StatesInTime.Insert(0, new StateInTime());
    }

    protected virtual void StartRewind()
    {
        isRewinding = true;
    }

    protected virtual void StopRewind()
    {
        isRewinding = false;
    }

    protected virtual void StopTime()
    {
        isTimeStopped = true;
    }

    protected virtual void ResumeTime()
    {
        isTimeStopped = false;
    }

    private void OnEnable()
    {
        inputAction.TimePowersControls.Enable();
    }

    private void OnDisable()
    {
        inputAction.TimePowersControls.Disable();
    }
}