using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void SinglePlayer()
    {
        // Player vs AI
    }
    public void TwoPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Multiplayer()
    {
        //Online
    }

    public void PauseGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Settings()
    {
        //Show Settings UI
    }

    public void AdFree()
    {
        //Prompt $0.99 charge
    }

    public void About()
    {
        //Links to all biggsgames sites
    }

    
}
