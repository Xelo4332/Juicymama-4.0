using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Deni
public class ScoreUI : MonoBehaviour
{    //We creating variables for we can add text, animation to our text and plus refrence to our player so we can add scores
    [SerializeField] private Text _textComponent;
    private Ship _player;
    private Animator _animator;

    private void Start()
    { //With help of generic code we will find our components  for animation, ship and so we can use OnPlayerScore change method
        _player = FindObjectOfType<Ship>();
        _animator = GetComponent<Animator>();
        _player.OnScoreChanged += OnPlayerScoreChanged;
    }
    //writes the number of points the player has in the text and subribes the event. Here we change our score animation with help of animator trigger.
    private void OnPlayerScoreChanged()
    {
        _textComponent.text = $"Score: {_player.Score}";
        _animator.SetTrigger("AddScore");
    }
    //This code unsubcribes the event
    private void OnDestroy()
    {
        _player.OnScoreChanged -= OnPlayerScoreChanged;
    }

}
