using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public static float recordTime = 10f;

    protected virtual List<StateInTime> StatesInTime { get; private set; }

    protected virtual StateInTime CurrentStateInTime { get; private set; }

    public bool isRewinding = false;
    bool isTimeStopped = false;
    PlayerInputActions inputAction;
    protected Rigidbody rb;

    protected void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.TimePowersControls.RewindTime.started += ctx => StartRewind();
        inputAction.TimePowersControls.RewindTime.canceled += ctx => StopRewind();
    }

    protected virtual void Start()
    {
        StatesInTime = new List<StateInTime>();
        rb = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else if(!isTimeStopped)
            Record();
    }

    protected virtual void Rewind()
    {
        if (StatesInTime.Count > 0)
        {
            CurrentStateInTime = StatesInTime[0];

            transform.position = CurrentStateInTime.position;
            transform.rotation = CurrentStateInTime.rotation;
            StatesInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    protected virtual void Record()
    {
        if (StatesInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            Debug.Log(StatesInTime.Count);
            StatesInTime.RemoveAt(StatesInTime.Count - 1);
        }

        StatesInTime.Insert(0, new StateInTime(transform.position, transform.rotation));
    }

    protected virtual void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    protected virtual void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    protected void StopTime()
    {
        isTimeStopped = true;
    }

    protected void ResumeTime()
    {
        isTimeStopped = true;
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
