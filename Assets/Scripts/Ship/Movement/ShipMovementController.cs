
using UnityEngine;

public class ShipMovementController
{ //Deni
    //We will use our rigidbody to move our ship, with help of readonly our variable going to be secured.
    private readonly Rigidbody _rigidBody;

    //We will make our rigidbody open to other scripts, but the orignal variable going to be closed or private.
    public ShipMovementController(Rigidbody rigidbody)
    {
        _rigidBody = rigidbody;
    }
    //Instead of using if's to move our character, we will use a simple movement that require input axis and vector3. We will move with help velocity not add force.
    public void Move(float movementSpeed)
    {
        var xDirection = Input.GetAxis("Horizontal");
        var newVelocity = new Vector3(xDirection * movementSpeed, 0, 0);
        _rigidBody.velocity = newVelocity;
    }
}
