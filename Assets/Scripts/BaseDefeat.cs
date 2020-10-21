using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDefeat : MonoBehaviour
{
    public Transform playerBase; 

    
    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerBase.childCount == 0) // looks at the bases that are left and to see if its zero
        {
            GameOver.isPlayerDead = true; // sets the player to dead
        }
    }


}
