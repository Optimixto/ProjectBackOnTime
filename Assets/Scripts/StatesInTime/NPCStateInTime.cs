using UnityEngine;

public class NPCStateInTime : StateInTimeTransform
{
    public int routineWaypointIndex;
    public float statusTimer;

    public NPCStateInTime(Vector3 _position, Quaternion _rotation, int index, float _statusTimer) : base(_position, _rotation)
    {
        routineWaypointIndex = index;
        statusTimer = _statusTimer;
    }

    public void ApplyState(Transform transform, NPC npcScript)
    {
        base.ApplyState(transform);
        npcScript.routine.currentWaypointIndex = routineWaypointIndex;
        npcScript.playerDetector.SetStatusTimer(statusTimer);
    }
}