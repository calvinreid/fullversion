using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Save a reference to the Rigidbody you want to affect with code.
    public Rigidbody rb;
    //This is the speed we will move the car forwards with.
    public float speed;
    //This is the speed we will move the car left and right with.
    public float sideSpeed;
    private void Start()
    {

        //We call this in start to get the Rigidbody component on the same object this script is attached to.
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {

        MoveForwards();

        //This is an input check to make sure we are holding down the A or D keys to move the car left or right.
        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        
    }

    
    //This function gets called in update to make sure the car is moving forward.
    public void MoveForwards()
    {
        //Use rb.AddForce to apply a physical force in a direction you provide. Then multiply by the speed to say how strong the push is.
        rb.AddForce(Vector3.forward * speed);
    }
    
    //This is used to move the player left.
    public void MoveLeft()
    {
        rb.AddForce(Vector3.left * sideSpeed);
    }

    //This is used to move the player right.
    public void MoveRight()
    {
        rb.AddForce(Vector3.right * sideSpeed);
    }

    //This checks for when your Collider on this object has collided with another object. "collision" is the other collider in question (the cars the player has to avoid).
    private void OnCollisionEnter(Collision collision)
    {
        //We can check if the object I collide with is an object with the tag "Obstacle"
        if(collision.collider.gameObject.CompareTag("Obstacle"))
        {
            //If so, store the GameManager class and call the endGame function.
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.LoseGame();
        }
    }
}
