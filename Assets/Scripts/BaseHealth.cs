using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public static float health = 5;

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        health--;
        Debug.Log("Decrease health of base[" + gameObject + "]");

    }

}
