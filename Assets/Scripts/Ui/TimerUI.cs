using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{//Deni
    [SerializeField] private Text _timerText;
    private RoundSettings _roundSettings;
    //We will find our script with help of generic code.
    //Vi också fångar up event och subcribe denna event. Every time we will use this event, then renderound time will activate.
    private void Awake()
    {
        _roundSettings = FindObjectOfType<RoundSettings>();
        _roundSettings.OnRoundTimeChanged += RenderRoundTime;
    }
    //This method catches current time of round then rendering it on text.
    private void RenderRoundTime(int roundTime)
    {
        _timerText.text = roundTime.ToString();
    }
    //We will unsrcibe the event so it will not result a issue during the gameplay.
    private void OnDestroy()
    {
        _roundSettings.OnRoundTimeChanged -= RenderRoundTime;
    }



}
