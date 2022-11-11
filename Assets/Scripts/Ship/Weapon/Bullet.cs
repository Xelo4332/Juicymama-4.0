using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
    //Deni
{
    //This variable adds a label so we can change speed of bullet. Here adds a rigidbody variable so we can move the bullet.
    [SerializeField] private float _speed;
    private Rigidbody _rigidBody;
    //Here in the start we will find our rigidbody component with help of generic code and with the bullet appears, it will move towards z always.
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = new Vector3(0, 0, _speed);
    }


}
