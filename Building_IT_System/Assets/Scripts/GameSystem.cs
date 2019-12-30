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
    public Vector3 respawnPos;
    public Menu menu;
    public bool Respawn = false;

    
    // Start is called before the first frame update
    void Start()
    {
        m_Gold = PlayerPrefs.GetInt("gold", 0);
        m_Health = PlayerPrefs.GetInt("maxhealth", 0);
        m_Damage = PlayerPrefs.GetInt("maxdamage", 0);
        m_Ammo = PlayerPrefs.GetInt("maxammo", 0);
        m_level = PlayerPrefs.GetInt("maxlevel", 0);
   
        currentLevelIndex = 0; 
  
        if(GetComponent<Menu>())
        {
            menu = GetComponent<Menu>();
        }
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            PlayerPrefs.SetInt("maxhealth", 0);
            PlayerPrefs.SetInt("maxdamage", 0);
            PlayerPrefs.SetInt("maxammo", 0);
            m_Health = PlayerPrefs.GetInt("maxhealth", 0);
            m_Damage = PlayerPrefs.GetInt("maxdamage", 0);
            m_Ammo = PlayerPrefs.GetInt("maxammo", 0);
        }
    }
    public void loadLevel()
    {
        string scene_name = levels[currentLevelIndex];
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        if(menu)
        {
            menu.enabled = false;
        }
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_name));
    }
    public void LoadNextLevel()
    {
        SceneManager.UnloadSceneAsync(levels[currentLevelIndex]);
        moveLevel(true);
        string scene_name = levels[currentLevelIndex];
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        Time.timeScale = 1;
        Respawn = false;
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
    public void IncreaseHealthLevel()
    {
        int r_gold = (m_Health + 1) * 5;

        if(m_Gold >= r_gold)
        {
            m_Health += 1;
            m_Health = Mathf.Clamp(m_Health, 0, 4);
            PlayerPrefs.SetInt("maxhealth", m_Health);
            m_Gold -= r_gold;
            SetCoin(m_Gold);
        }
       
    }
    public void IncreaseDammageLevel()
    {
        int r_gold = (m_Damage + 1) * 5;

        if (m_Gold >= r_gold)
        {
            m_Damage += 1;
            m_Damage = Mathf.Clamp(m_Damage, 0, 4);
            PlayerPrefs.SetInt("maxdamage", m_Damage);
            m_Gold -= r_gold;
            SetCoin(m_Gold);
        }
       
    }
    public void IncreaseAmmoLevel()
    {
        int r_gold = (m_Ammo + 1) * 5;

        if (m_Gold >= r_gold)
        {
            m_Ammo += 1;
            m_Ammo = Mathf.Clamp(m_Ammo, 0, 4);
            PlayerPrefs.SetInt("maxammo", m_Ammo);
            m_Gold -= r_gold;
            SetCoin(m_Gold);
        }
       
    }
    public void BackfromGame()
    {
        SceneManager.UnloadSceneAsync(levels[currentLevelIndex]);
        if (menu)
        {
            menu.enabled = true;
            menu.BackButtonFromGame();
        }
        Respawn = false;
    }
    public void RetryLevel()
    {
        SceneManager.UnloadSceneAsync(levels[currentLevelIndex]);
        string scene_name = levels[currentLevelIndex];
        SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        Respawn = true;
    }
    public void SetCoin(int amount)
    {
        m_Gold = amount;
        PlayerPrefs.SetInt("gold", m_Gold);
    }
    public void setRespawnPos(Vector3 pos)
    {
        respawnPos = pos;
    }
    public Vector3 spawning(Vector3 pos)
    {
        if(Respawn)
        {
            return respawnPos;
        }
        else
        {
            return pos; 
        }
    }
    public int getCost(int type)
    {
        if (type == 1)
        {
            return (m_Health + 1) * 5;
        }
        if (type == 2)
        {
            return (m_Damage + 1) * 5;
        }
        if (type == 3)
        {
            return (m_Ammo + 1) * 5;
        }
        return 0;
    }
}
