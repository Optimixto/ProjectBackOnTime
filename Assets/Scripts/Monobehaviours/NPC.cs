using System;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Routine routine;
    public Waypoint LastKnownPositionWaypoint;
    public float rotationSpeed = 4f;
    public PlayerDetector playerDetector;
    public Animator AIAnimator;

    private Waypoint currentTarget;
    private NavMeshAgent agent;

    private void Awake()
    {
        playerDetector = this.GetComponentInChildren<PlayerDetector>();
        agent = this.GetComponent<NavMeshAgent>();
        AIAnimator = this.GetComponent<Animator>();

        playerDetector.awarenessStatuses.defaultMovSpeed = agent.speed;
    }

    internal void GoToLastSeenPosition()
    {
        SetTarget(LastKnownPositionWaypoint);
        transform.LookAt(LastKnownPositionWaypoint.transform);
        LastKnownPositionWaypoint.UpdateRotation(transform);

        GoToCurrentWaypoint();
    }

    internal bool ArrivedAtWaypoint(Waypoint waypoint)
    {
        var heading = transform.position - currentTarget.ActionLocation;

        if (heading.sqrMagnitude <= 1)
        {
            agent.isStopped = true;
            return true;
        }
        else
            return false;
    }

    public void GoToCurrentWaypoint()
    {
        agent.SetDestination(currentTarget.ActionLocation);
        agent.isStopped = false;
    }

    public void StopMovement()
    {
        agent.isStopped = true;
    }

    public void ChangeSpeed(float speed)
    {
        agent.speed = speed;
    }

    public bool ReachedCurrentWaypoint()
    {
        var heading = transform.position - currentTarget.ActionLocation;

        return heading.sqrMagnitude <= 1;
    }

    public void SetTarget(Waypoint waypoint)
    {
        currentTarget = waypoint;
    }

    public void RotateTowardsWaypoint(Waypoint waypoint)
    {
        transform.LookAt(waypoint.transform);
    }

    public void RotateTowardsDirection(Vector3 direction)
    {
        direction.Normalize();
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}