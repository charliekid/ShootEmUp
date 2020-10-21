using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Transform bullet;
    public float speed = 1;
    
    public AudioSource audioSource;
    public AudioClip playerHitClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;
        if (bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.tag == "Base")
        {
            //Debug.Log("We hit a base");
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            Destroy(gameObject);

        }
    }

}
