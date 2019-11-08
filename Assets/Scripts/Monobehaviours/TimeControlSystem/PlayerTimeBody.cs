using UnityEngine;

public class PlayerTimeBody : TimeBody
{
    CharacterController characterController;
    PlayerMovement playerMovementScript;

    protected override void Start()
    {
        base.Start();

        characterController = GetComponent<CharacterController>();
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    protected override void StartRewind()
    {
        base.StartRewind();

        isRewinding = true;

        characterController.enabled = false;
        playerMovementScript.enabled = false;
    }

    protected override void StopRewind()
    {
        isRewinding = false;

        characterController.enabled = true;
        playerMovementScript.enabled = true;
    }
}
