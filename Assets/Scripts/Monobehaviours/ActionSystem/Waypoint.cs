using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public ActionCollection defaultActionCollection;
    public bool isResettable = true;

    [HideInInspector]
    public Vector3 actionLocation;

    public bool AllActionsDone
    {
        get; private set;
    }

    protected virtual void Awake()
    {
        UpdateActionLocation(transform);
    }

    public void ResetWaypoint()
    {
        if (isResettable)
        {
            defaultActionCollection.ResetActions();
            UpdateAllActionsDone();
        }
    }

    //Performs all actions associated with this Waypoint
    public virtual void Act()
    {
        UpdateAllActionsDone();

        if (!AllActionsDone)
        {
            defaultActionCollection.Act();
        }
    }

    //Checks if all Actions are done
    public void UpdateAllActionsDone()
    {
        AllActionsDone = defaultActionCollection.CheckIfAllActionsAreDone();
    }

    public void UpdateActionLocation(Transform transform)
    {
        actionLocation = transform.position;
    }

    public void UpdateRotation(Transform referenceTransform)
    {
        transform.forward = referenceTransform.forward;
    }

    private bool RequiresRotation()
    {
        for (int i = 0; i < defaultActionCollection.actions.Length; i++)
        {
            if (defaultActionCollection.actions[i] is RotateTowardsAction)
                return true;
            else if (defaultActionCollection.actions[i] is LookAroundAction)
                return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, .2f);

        if (RequiresRotation())
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}