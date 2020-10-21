// Some code was made with the help of this tutorial https://www.youtube.com/watch?v=cnfwNzpoIlA

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public Transform player;

    private float amplitude = 1;
    public float velocityPlayer = 0;
  
    public float maxBoundary, minBoundary;
  
    // Player score stuff
    public static float playerScore = 0;
    [SerializeField] public Text scoreText;
    
    // High Score stuff
    public Text highScoreText;
    public static float highScore = 0;

    private Animator playerAnimator;
    
    // Audio stuff
    public AudioSource audioSource;
    
    // Start functions
    void Start()
    {
        playerAnimator = GetComponent<Animator>(); 
    }

    void Update()
    {
        scoreText.text = String.Format("Score : {0:0000}" , playerScore);
        highScoreText.text = String.Format("High Score : {0:0000}", highScore);

        velocityPlayer = Input.GetAxis("Horizontal");
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Shoot");
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            player.gameObject.GetComponent<Animator>().SetTrigger("Death");
            Destroy(other.gameObject);
            StartCoroutine(destroyPlayer());
            GameOver.isPlayerDead = true;
        } 
    }

    // Waits a moment so that the explosion clip plays
    IEnumerator  destroyPlayer()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}

