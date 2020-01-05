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
    public Outline[] myWires = new Outline[0];

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
            GreenWire();
        }
        else
        {
            LockedImage();
            RedWire();
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

    private void RedWire()
    {
        for (int i = 0; i < myWires.Length; i++)
            myWires[i].OutlineColor = Color.red;
    }

    private void GreenWire()
    {
        for (int i = 0; i < myWires.Length; i++)
            myWires[i].OutlineColor = Color.green;
    }
}