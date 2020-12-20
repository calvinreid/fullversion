using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //This will follow the object
    public Transform targetToFollow;
    
    
    //This will keep the distance between the object
    public Vector3 offset;
    
    void Start()
    {
        //This provides me with a vector3 with the distance between the two objects
        offset = targetToFollow.position - transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        //Maintain the distance
        Vector3 newPosition = targetToFollow.position - offset;

        
        transform.position = newPosition; 
    }
}
