using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("Demo", LoadSceneMode.Additive);
        if(menuUI)
        {
            menuUI.SetActive(false);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
