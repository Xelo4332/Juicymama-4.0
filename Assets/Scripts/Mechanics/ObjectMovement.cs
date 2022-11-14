using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{   //Deni
    //This script is very important, so the object could move we create a Rigidbody variable
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rigidBody;

    //With this generic code, we will find compenent rigidbody and the script will know that our variable going to be rigidbody
    public virtual void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    //This is what makes object move. We using velocity movement instead of addforce. I thought velocity works better with this. 
    //You may ask why I used fixed update, fixed update makes frame updates equal for all devices, in regular updates in depends on your hardware and will run slower or faster.
    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(0, 0, -_movementSpeed);

    }

}
