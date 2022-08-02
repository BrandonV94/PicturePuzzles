using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int sceneOffSet = 2; 
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
        var level = btn.GetComponentInChildren<TMP_Text>().text;
        int sceneIndex = int.Parse(level) + sceneOffSet;
        Debug.Log("Level = " + level + "Index value = " + sceneIndex);
        if(sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            SceneManager.LoadScene("Place Holder");
        }
    }
}
