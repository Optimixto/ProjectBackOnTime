using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public float viewDistance = 10f;
    public AwarenessStatuses awarenessStatuses;
    public LayerMask viewMask;

    private Light visionLight;
    private NPC npcScript;
    private NPCTimeBody timeBody;
    private float viewAngle;

    public Transform Player
    {
        get; private set;
    }

    public float StatusTimer
    {
        get; private set;
    }

    private void Start()
    {
        visionLight = transform.GetComponent<Light>();

        npcScript = transform.parent.GetComponentInChildren<NPC>();
        timeBody = transform.parent.GetComponentInChildren<NPCTimeBody>();

        if (visionLight == null)
        {
            Debug.LogError("Missing light component.");
        }

        awarenessStatuses.unawareColor = visionLight.color;
        viewAngle = visionLight.spotAngle;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        awarenessStatuses.Initialize();
    }

    private void Update()
    {
        if (!timeBody.isRewinding)
            NormalBehavior();
        else
        {
            npcScript.AIAnimator.SetBool("SeeingPlayer", false);
            UpdateAwarenessColor();
        }
    }

    private void NormalBehavior()
    {
        if (CanSeePlayer())
        {
            npcScript.AIAnimator.SetBool("SeeingPlayer", true);
            npcScript.AIAnimator.SetBool("DoneInvestigating", false);
            npcScript.StopMovement();
            npcScript.LastKnownPositionWaypoint.UpdateActionLocation(Player);
            RaiseCurrentStatusTimer();

            if (StatusTimer <= awarenessStatuses.timeToSuspicious)
            {
                visionLight.color = awarenessStatuses.unawareColor;
            }
            else if (StatusTimer >= awarenessStatuses.timeToSuspicious && StatusTimer < awarenessStatuses.TotalTimeToAlerted)
            {
                npcScript.AIAnimator.SetBool("Suspicious", true);
                visionLight.color = awarenessStatuses.suspiciousColor;
            }
            else if (StatusTimer >= awarenessStatuses.TotalTimeToAlerted)
            {
                npcScript.AIAnimator.SetBool("Alerted", true);
                visionLight.color = awarenessStatuses.alertedColor;
            }
        }
        else if (StatusTimer > 0)
        {
            npcScript.AIAnimator.SetBool("SeeingPlayer", false);

            if (npcScript.AIAnimator.GetBool("DoneInvestigating"))
            {
                ReduceCurrentStatusTimer();

                visionLight.color = awarenessStatuses.unawareColor;
                npcScript.AIAnimator.SetBool("Suspicious", false);
                npcScript.AIAnimator.SetBool("Alerted", false);
            }
        }
    }

    public bool CanSeePlayer()
    {
        Vector3 offset = Player.position - transform.position;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen < viewDistance * viewDistance)
        {
            Vector3 dirToPlayer = offset.normalized;
            float angleBetweenNpcAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);

            if (angleBetweenNpcAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, Player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void RaiseCurrentStatusTimer()
    {
        StatusTimer += Time.deltaTime;
    }

    public void UpdateAwarenessColor()
    {
        if (StatusTimer <= awarenessStatuses.timeToSuspicious)
        {
            visionLight.color = awarenessStatuses.unawareColor;
        }
        else if (StatusTimer >= awarenessStatuses.timeToSuspicious && StatusTimer < awarenessStatuses.TotalTimeToAlerted)
        {
            visionLight.color = awarenessStatuses.suspiciousColor;
        }
        else if (StatusTimer >= awarenessStatuses.TotalTimeToAlerted)
        {
            visionLight.color = awarenessStatuses.alertedColor;
        }
    }

    public void ReduceCurrentStatusTimer()
    {
        if (StatusTimer > 0 && !CanSeePlayer())
            StatusTimer -= Time.deltaTime;
    }

    public void SetStatusTimer(float newTime)
    {
        StatusTimer = newTime;

        if (StatusTimer <= awarenessStatuses.timeToSuspicious)
        {
            npcScript.AIAnimator.SetBool("Suspicious", false);
            npcScript.AIAnimator.SetBool("Alerted", false);
        }
        else if (StatusTimer >= awarenessStatuses.timeToSuspicious && StatusTimer < awarenessStatuses.TotalTimeToAlerted)
        {
            npcScript.AIAnimator.SetBool("Suspicious", true);
            npcScript.AIAnimator.SetBool("Alerted", false);
        }
        else if (StatusTimer >= awarenessStatuses.TotalTimeToAlerted)
        {
            npcScript.AIAnimator.SetBool("Suspicious", true);
            npcScript.AIAnimator.SetBool("Alerted", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}