using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
