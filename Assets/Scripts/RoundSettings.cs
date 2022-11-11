using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundSettings : MonoBehaviour
{
    public event Action<int> OnRoundTimeChanged;
    [SerializeField] private int _roundTime;
    [SerializeField] private int _highScoreSceneIndex;
    //Start our coroutine and sending our event signal
    private void Start()
    {
        StartCoroutine(RoundTimeRoutine());
        OnRoundTimeChanged?.Invoke(_roundTime);
    }
    //N�r det �r mer �n 0, du kommer koden v�nta en second och sen ta bort 1 minus. Det kommer f�rst�ta tills det kommer till 0.
    //Vi ocks� aktiverar event och vi ska skicka vindare til andra script.
    private IEnumerator RoundTimeRoutine()
    {
        while (_roundTime > 0)
        {
            yield return new WaitForSeconds(1);
            _roundTime--;
            OnRoundTimeChanged?.Invoke(_roundTime);
        }
        SceneManager.LoadScene(_highScoreSceneIndex);
    }
 }
