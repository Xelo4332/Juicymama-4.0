using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneHandler : MonoBehaviour
{
    [SerializeField] private int _gameSceneIndex;

    public void Restart()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }

}
