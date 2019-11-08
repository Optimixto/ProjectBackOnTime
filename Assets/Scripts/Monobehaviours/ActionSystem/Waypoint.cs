using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public ActionCollection defaultActionCollection;
    public Vector3 Location;
    
    public bool AllActionsDone
    {
        get; private set;
    }

    private void Awake()
    {
        UpdateLocation(transform);
    }

    public void ResetWaypoint(Animator animator)
    {
        defaultActionCollection.ResetActions();
        UpdateAllActionsDone();
    }

    //Performs all actions associated with this Waypoint
    public virtual void Act()
    {
        UpdateAllActionsDone();

        if(!AllActionsDone)
        {
            defaultActionCollection.Act();
        }
    }

    //Checks if all Actions are done
    public void UpdateAllActionsDone()
    {
        AllActionsDone = defaultActionCollection.CheckIfAllActionsAreDone();
    }

    public bool RequiresRotation()
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

    public void UpdateLocation(Transform transform)
    {
        Location = transform.position;
        base.transform.position = Location;
    }

    public void UpdateRotation(Transform referenceTransform)
    {
        transform.forward = referenceTransform.forward;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, .2f);

        if(RequiresRotation())
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}