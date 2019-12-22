using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour
{
    public Image lockedCanvas;
    public Image hackingCanvas;
    public Image unlockedCanvas;
    public PlayerWaypoint myComputer;

    private void Start()
    {
        if (myComputer == null)
            Debug.LogError("Missing Player Waypoint");
    }

    private void FixedUpdate()
    {
        if (myComputer.isInteracting)
        {
            HackingImage();
        }
        else if (myComputer.AllActionsDone)
        {
            UnlockedImage();
        }
        else
        {
            LockedImage();
        }
    }

    private void UnlockedImage()
    {
        lockedCanvas.enabled = false;
        hackingCanvas.enabled = false;
        unlockedCanvas.enabled = true;
    }

    private void HackingImage()
    {
        lockedCanvas.enabled = false;
        hackingCanvas.enabled = true;
        unlockedCanvas.enabled = false;
    }

    private void LockedImage()
    {
        lockedCanvas.enabled = true;
        hackingCanvas.enabled = false;
        unlockedCanvas.enabled = false;
    }
}