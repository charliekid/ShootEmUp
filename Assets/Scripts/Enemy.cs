using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip explosionClip;
    // public Transform enemy; 
    // public float speed;
    //
    // Start is called before the first frame update
    void Awake()
    {
        // InvokeRepeating("MoveEnemy", 0.05f, 0.3f);       
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Friendly fire");
        }
        else
        {
            // Triggers death 
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            StartCoroutine(destroyEnemy());
            //audioSource.PlayOneShot(explosionClip);
        }
    }
    // Ensure we see the death animation before it dies
    IEnumerator  destroyEnemy()
    {
        yield return new WaitForSeconds(1);
        //Debug.Log("finished waiting for 1 seconds");
        Destroy(gameObject);
    }
    
}
