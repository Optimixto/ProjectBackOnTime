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

    private PlayerMovement playerMovement;

    bool isPlayerAtExit;
    bool isPlayerCaught;
    float timer;

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
            if(!Physics.Linecast(playerPosition, other.transform.position, obstaclesLayer))
                isPlayerCaught = true;
        }            
        else if (other.CompareTag("Goal"))
            isPlayerAtExit = true;
    }

    void Update()
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

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
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
}
