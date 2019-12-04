using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuUI;
    [SerializeField]
    GameSystem GS;
    public Text LevelText; 
    private void Update()
    {
        if(GS)
        {
            LevelText.text =(GS.currentLevelIndex + 1).ToString();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
