using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // flag to point to
    public Transform flag;
    // player to follow
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // always rotate to look at the flag 
        transform.LookAt(flag);
        // follow player 
        transform.position = player.position + offset;
    }
    
   }
