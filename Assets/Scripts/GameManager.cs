using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    void Start()
    {
       if(gameManager == null)
       {
            gameManager = this;
       }

       if(timeToEnd <= 0) 
       {
            timeToEnd = 100;
       }

        Debug.Log("Time: " + timeToEnd + " s");
        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");
        
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reoad?");
        } else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

}
