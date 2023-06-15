using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Retry()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
