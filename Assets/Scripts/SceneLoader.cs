using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1); // 1 = main menu scene.
    }

    public void QuitApplication()
    {
        Debug.Log("Closing application.");
        Application.Quit();
    }

    public void LoadLevel(Button btn)
    {
        var level = btn.name;
        if(SceneManager.GetSceneByName(level).IsValid()) // Check to see if level is available
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            SceneManager.LoadScene("Place Holder");
        }
    }
}
