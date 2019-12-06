using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBarHandler : MonoBehaviour
{
    private PlayerTimeBody playerTimeBody;
    public Slider sliderRewind;
    public Slider sliderStop;

    private void Start()
    {
        playerTimeBody = FindObjectOfType<PlayerTimeBody>();
    }

    private void Update()
    {
        sliderRewind.value = playerTimeBody.CurrentRewindTimePercentage();
        sliderStop.value = playerTimeBody.CurrentStopTimePercentage();
    }
}