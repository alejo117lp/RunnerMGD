using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUIManager : MonoBehaviour
{
    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("BYE");
        Application.Quit();
    }
}
