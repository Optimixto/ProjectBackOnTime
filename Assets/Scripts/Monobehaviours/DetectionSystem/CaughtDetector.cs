using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaughtDetector : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public bool isPlayerCaught;

    private PlayerMovement playerMovement;
    private PlayerInputActions inputAction;
    private bool isPlayerAtExit;
    private float timer;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 playerPosition = transform.parent.transform.position;
        int obstaclesLayer = LayerMask.GetMask("Obstacles");

        if (other.CompareTag("Guard"))
        {
            if (!Physics.Linecast(playerPosition, other.transform.position, obstaclesLayer))
                isPlayerCaught = true;
        }
        else if (other.CompareTag("Goal"))
            isPlayerAtExit = true;
        else if (other.CompareTag("InteractiveWaypoint"))
        {
            if (inputAction.PlayerMovementControls.Interact.ReadValue<float>() != 0 && !other.GetComponent<PlayerWaypoint>().AllActionsDone)
                other.GetComponent<PlayerWaypoint>().isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractiveWaypoint"))
        {
            other.GetComponent<PlayerWaypoint>().isInteracting = false;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        Time.timeScale = 0f;
        playerMovement.enabled = false;

        timer += Time.unscaledDeltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                Time.timeScale = 1f;
                playerMovement.enabled = true;
            }
            else
            {
                Debug.Log("Quit game...");
                Application.Quit();
            }
        }
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}