using UnityEngine;

public class NPCStateInTime : StateInTime
{
    public int routineWaypointIndex;
    public float statusTimer;

    public NPCStateInTime(Vector3 _position, Quaternion _rotation, int index, float _statusTimer) : base(_position, _rotation)
    {
        routineWaypointIndex = index;
        statusTimer = _statusTimer;
    }
}
