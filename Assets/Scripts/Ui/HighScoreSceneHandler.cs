using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreSceneHandler : MonoBehaviour
{
    [SerializeField] private Text _highScoreText;
    [SerializeField] private int _getSceneIndex;


    //Load save highscore from playerprefs
    private void Start()
    {
        _highScoreText.text = $"High score: {PlayerPrefs.GetInt("HighScore")}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(_getSceneIndex);
    }


}
