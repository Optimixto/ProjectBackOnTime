using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AwarenessStatuses : ScriptableObject
{
    [HideInInspector]
    public Color unawareColor;

    public float timeToSuspicious = 2f;
    public Color suspiciousColor;

    public float timeToAlerted = 3f;
    public Color alertedColor;

    [HideInInspector]
    public float defaultMovSpeed;
    public float AlertedMovSpeed { get; private set; }
    public float SuspiciousMovSpeed { get; internal set; }

    public float TotalTimeToAlerted { get; private set; }

    public void Initialize()
    {
        SuspiciousMovSpeed = defaultMovSpeed * 1.5f;
        AlertedMovSpeed = defaultMovSpeed * 2f;
        TotalTimeToAlerted = timeToSuspicious + timeToAlerted;
    }
}
