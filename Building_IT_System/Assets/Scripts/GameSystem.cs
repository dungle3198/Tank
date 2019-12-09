using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public int m_Gold = 0;
    public int m_Health = 0;
    public int m_Damage = 0;
    public int m_Ammo = 0;
    public int m_level = 0;

    public int currentLevelIndex = 0;
    public List<string> levels = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        m_Gold = PlayerPrefs.GetInt("gold", 0);
        m_Health = PlayerPrefs.GetInt("maxhealth", 0);
        m_Damage = PlayerPrefs.GetInt("maxdamage", 0);
        m_Ammo = PlayerPrefs.GetInt("maxammo", 0);
        m_level = PlayerPrefs.GetInt("maxlevel", 0);
   
        currentLevelIndex = 0; 
  
   
    }
    public void loadLevel()
    {
        string scene_name = levels[currentLevelIndex];
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_name));
    }
    public void LoadNextLevel()
    {
        SceneManager.UnloadSceneAsync(levels[currentLevelIndex]);
        moveLevel(true);
        string scene_name = levels[currentLevelIndex];
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_name));
    }
    public void moveLevel(bool nextorback) // next is true, back is false
    {
        if(nextorback)
        {
            currentLevelIndex++;
            if(currentLevelIndex > levels.Count-1)
            {
                currentLevelIndex = 0;
            }
        }
        else
        {
            currentLevelIndex--;
            if (currentLevelIndex < 0)
            {
                currentLevelIndex = levels.Count - 1;
            }
        }
    }
}
