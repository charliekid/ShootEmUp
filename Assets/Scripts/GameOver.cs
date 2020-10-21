using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead = false;
    public Text gameOver; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false; // ensure that we dont see this at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            Time.timeScale = 0; // freezes the game
            gameOver.enabled = true; // displays gameover on the screen and everything stops moving
            SceneManager.LoadScene("CreditsScene");
            //loadCredits();
        }
    }

     IEnumerator loadCredits()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("CreditsScene");
        Debug.Log("loading CreditScene scene");
    }
}
