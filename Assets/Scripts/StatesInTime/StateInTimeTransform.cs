using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInTimeTransform : StateInTime
{
    public Vector3 position;
    public Quaternion rotation;

    public StateInTimeTransform(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }

    public void ApplyState(Transform transform)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
}