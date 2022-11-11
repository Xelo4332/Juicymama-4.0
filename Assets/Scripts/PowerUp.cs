using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : SpawnObjects
    //Deni
    //This script arver från spawn object
{   //This Variable used for so we can add audio clip in the unity.
    [SerializeField] private AudioClip _pickSound;
    private void OnTriggerEnter(Collider col)
    {
        //This script will find ship script componenet, if it will collide with a script holder. It will play the sound and destroy.
        if(col.TryGetComponent(out Ship _player))
        {
            AudioManager.Instance.PlaySound(_pickSound);
            Destroy(gameObject);
        }
    }

}
