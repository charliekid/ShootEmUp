using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToLoad());
    }
    
    

    // Returns back to the main menu
    IEnumerator waitToLoad()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("MainMenu");
        Debug.Log("loading mainmenu scene");
    } 
}
