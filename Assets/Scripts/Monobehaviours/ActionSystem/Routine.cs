using System;
using UnityEngine;

public class Routine : MonoBehaviour
{
    public int currentWaypointIndex;

    public Waypoint CurrentWaypoint
    {
        get; private set;
    }

    private Transform[] waypointsTransforms;

    private void Awake()
    {
        waypointsTransforms = new Transform[transform.childCount];

        InitializeRoutine();
    }

    public void InitializeRoutine()
    {
        for (int i = 0; i < waypointsTransforms.Length; i++)
        {
            waypointsTransforms[i] = transform.GetChild(i);

            CurrentWaypoint = waypointsTransforms[i].GetComponent<Waypoint>();

            if (CurrentWaypoint == null)
            {
                Debug.LogError("Missing Waypoint component in " + transform.name);
            }
        }

        CurrentWaypoint = waypointsTransforms[0].GetComponent<Waypoint>();
    }

    public void PerformWaypointUntilDone(Animator animator)
    {
        if (!CurrentWaypoint.AllActionsDone)
        {
            CurrentWaypoint.Act();
        }
        else
        {
            IncrementWaypointIndex();
            animator.SetTrigger("AllActionsDone");
        }
    }

    public void IncrementWaypointIndex()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypointsTransforms.Length;
        UpdateCurrentWaypointByIndex(currentWaypointIndex);
    }

    public void UpdateCurrentWaypointByIndex(int index)
    {
        if (index <= waypointsTransforms.Length)
        {
            currentWaypointIndex = index;
            CurrentWaypoint = waypointsTransforms[currentWaypointIndex].GetComponent<Waypoint>();
        }
        else
            Debug.LogError("Trying to set wrong value in index");
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 startPosition = transform.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        Gizmos.color = Color.white;

        foreach (Transform waypointTransform in transform)
        {
            Gizmos.DrawLine(previousPosition, waypointTransform.position);
            previousPosition = waypointTransform.position;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(startPosition, .4f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(previousPosition, startPosition);
    }
}