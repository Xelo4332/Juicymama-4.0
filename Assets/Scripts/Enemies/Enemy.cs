using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpawnObjects
{ //Deni
    //We adding some varaibles so we can use audioclips and find player with help with his script
    [SerializeField] private AudioClip _onDestroySound;
    private Ship _player;
    [SerializeField] private ParticleSystem Effect;
    [SerializeField] ShakeBehavior sc;


    //We will find our Ship script for score adding with help of generic code.
    public override void Start()
    {
        base.Start();
        _player = FindObjectOfType<Ship>();
        sc = FindObjectOfType<ShakeBehavior>();
    }

   //If enemy will collide object that hold script Bullet, then it will play a sound, activate onenemykillmethod for score add, destroy bullet and destroy the object.
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Bullet bullet))
        {
            sc.TriggerShake();
            AudioManager.Instance.PlaySound(_onDestroySound);
            _player.OnEnemyKill();
            Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }

}
