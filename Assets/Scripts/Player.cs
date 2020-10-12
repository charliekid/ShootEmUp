using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  
  public Transform shottingOffset;
  
  public Transform player;

  private float amplitude = 1;
  
  public float velocityPlayer = 0;
  
  public float maxBoundary, minBoundary;

  // Update is called once per frame
    void Update()
    {
      velocityPlayer = Input.GetAxis("Horizontal");
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);
      }
      
      // Moves the player within the boundaries
      if (player.position.x < minBoundary && velocityPlayer < 0)
      {
        velocityPlayer = 0;
      }
      else if (player.position.x > maxBoundary && velocityPlayer > 0)
      {
        velocityPlayer = 0;
      }

      player.position += Vector3.right * velocityPlayer * amplitude;
    }
}
