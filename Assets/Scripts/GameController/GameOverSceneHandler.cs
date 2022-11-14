using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Deni
public class GameOverSceneHandler : MonoBehaviour
{
    [SerializeField] private int _gameSceneIndex;

    //Changing scene to assinged variable int number
    public void Restart()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }

}
