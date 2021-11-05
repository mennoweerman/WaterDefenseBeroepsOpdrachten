using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 

    private bool gameEnded = false;
    
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void Endgame()
    {
        gameEnded = true;
        Debug.Log("game over");
    }

}
