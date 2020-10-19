using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{

  private Rigidbody2D myRigidbody2D;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed; 
      //Debug.Log("Wwweeeeee");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      
      if (other.gameObject.tag == "Enemy")
      {
        //Debug.Log(other.gameObject + "Other gameobject");
        //Debug.Log(gameObject + " Gameobject");
        Destroy(other.gameObject);
        Destroy(gameObject);
        // Increase player score we want to see what kind of enemy at this point\
        
        // this might be dumb but its the answer for now. we will store the to search the begining
        String enemyName = other.gameObject.name;
        char enemyType = enemyName[5];
        Debug.Log("Enemy Type" + enemyType);
        switch (enemyType)
        {
          case 'R':
          case 'T': // Tina
            Player.playerScore += 30;
            break;
          case 'O':
          case 'G':  //Gene
            Player.playerScore += 20;
            break;
          case 'Y':
          case 'L': // Louise
            Player.playerScore += 10;
            break;
          case 'S':
          case 'K': // kuchiKopi
            Player.playerScore += 100;
            break;
          default:
            break;
        }
        
      }
      else if (other.gameObject.tag == "Base")
      {
        Destroy(gameObject);
      }
      else if (other.gameObject.tag == "Player")
      {
        Destroy(other.gameObject);
        Destroy(gameObject);
      }
      
    }

}
