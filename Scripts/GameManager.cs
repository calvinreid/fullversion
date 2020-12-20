using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //I will store this so I can spawn an obstacle a certian distance in front of the player.
    public Transform playerCarTransform;

    //This will randomly spawn all the obstacles the player has to avoid
    public GameObject[] carsToSpawn;

    public float timerToGenerate;
    public float minimumTimeToWait, maximumTimeToWait;

    public void Update()
    {
        //This counts down in ingame time. 
        timerToGenerate -= Time.deltaTime;

        //Check if it goes below 0
        if(timerToGenerate < 0)
        {
            //If it does generate an obstacle
            GenerateObstacle();
            //Reset the timer so the loop can continue
            timerToGenerate = Random.Range(minimumTimeToWait, maximumTimeToWait);
        }
    }

    //Randomly generate objects when the game is running
    public void GenerateObstacle()
    {
        //I am getting a random GameObject from the carsToSpawn array then I will use it below to spawn it
        GameObject carToSpawn = carsToSpawn[Random.Range(0, carsToSpawn.Length)];
        //Use "carToSpawn" to create a car. Then I store it in a GameObject reference so I can make changes to it
        GameObject carObstacle = Instantiate(carToSpawn);

        //I am moving the newly created carObstacle to a new position.
        carObstacle.transform.position = new Vector3(Random.Range(-12f, 12f), playerCarTransform.position.y, playerCarTransform.position.z + Random.Range(75, 150));
    }


    public void WinGame()
    {

        LevelEndLogic endLogic = FindObjectOfType<LevelEndLogic>();
        //In this game I am calling the WinGameScreen function to activate the winning condition screen.
        endLogic.WinGameScreen();
    }
    public void LoseGame()
    {
        LevelEndLogic endLogic = FindObjectOfType<LevelEndLogic>();
        endLogic.LoseGameScreen();
    }
}
