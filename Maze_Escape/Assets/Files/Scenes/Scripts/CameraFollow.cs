using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // game object to follow
    public GameObject player;
    void Start()
    {
    }

    void Update()
    {   
           // rotate the camera to be top-down view 
        transform.rotation = Quaternion.Euler(70,transform.rotation.y,transform.rotation.z);
        // always follow the game object
        transform.position = new Vector3(player.transform.position.x,10,player.transform.position.z-3);       
        
    }
}
