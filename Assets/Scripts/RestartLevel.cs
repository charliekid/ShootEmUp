using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Player.playerScore > Player.highScore)
            {
                Player.highScore = Player.playerScore;

            }
            Player.playerScore = 0;
            GameOver.isPlayerDead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("GameScene");
            
            
        }
    }
}
