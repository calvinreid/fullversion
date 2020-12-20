using UnityEngine;
using System.Collections;


public class LevelEndTrigger : MonoBehaviour
{
    //This function gets called whenever an object passes through the collider.

    
    public void OnTriggerEnter(Collider other)
    {
        
        //This is used to check if our object has collided with the "car" object
        if(other.CompareTag("Car"))
        {
           
            GameManager gameManager = FindObjectOfType<GameManager>();
            //Call the win game because this means the car reached the end.
            gameManager.WinGame();
        }
    }

}