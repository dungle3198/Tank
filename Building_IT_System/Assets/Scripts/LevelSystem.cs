using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    bool completed = false;
    [SerializeField]
    Vector3 SpawnPostion = new Vector3(0, 0, 0);
    [SerializeField]
    Player player;
    [SerializeField]
    GameObject ResultBoard;
    [SerializeField]
    Text ResultText;
    [SerializeField]
    GameObject RetryButton;
    [SerializeField]
    GameObject NextLevelButton;
    [SerializeField]
    GameSystem GS;
    [SerializeField]
    GameObject pauseScreen;
    [SerializeField]
    int coin; 
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
            SpawnPostion = player.transform.position;
        }
        if (ResultBoard)
        {
            ResultBoard.SetActive(false); 
        }
        if(RetryButton)
        {
            RetryButton.SetActive(false);
        }
        if(FindObjectOfType<GameSystem>())
        {
            GS = FindObjectOfType<GameSystem>();
            coin = GS.m_Gold;
        }
        SceneManager.SetActiveScene(this.gameObject.scene);
    }

    // Update is called once per frame
    void Update()
    {

        SetPauseScreen();
    }
    public void spawning()
    {
        if(player)
        {
            player.transform.position = SpawnPostion;
            player.Respawn();
        }
    }
    public void Retry()
    {
        Time.timeScale = 1;
        if (GS)
        {
            GS.RetryLevel();
        }
        
    }
    public void Menu()
    {
    }
    public void Result(bool on)
    {

       if(pauseScreen)
        {
            if(pauseScreen.active ==false )
            {
                Cursor.lockState = CursorLockMode.None;
                if (on)
                {
                    if (ResultBoard)
                    {
                        ResultBoard.SetActive(true);
                        Time.timeScale = 0;
                        if (completed)
                        {
                            
                            if (ResultText)
                            {
                                ResultText.text = "LEVEL " + gameObject.scene.buildIndex.ToString() +
                                    "\nYOU HAVE COMPLETED THE LEVEL!";
                            }
                            if (NextLevelButton)
                            {
                                NextLevelButton.SetActive(true);
                                if (GS)
                                {
                                    if (GS.currentLevelIndex == GS.levels.Count - 1)
                                    {
                                        NextLevelButton.SetActive(false);
                                        
                                    }
                                    GS.SetCoin(coin);
                                }

                            }
                            if (RetryButton)
                            {
                                RetryButton.SetActive(false);
                            }

                        }
                        else
                        {
                            if (ResultText)
                            {
                                ResultText.text = "LEVEL " + gameObject.scene.buildIndex.ToString() + "\nYOU ARE DEAD, YOU WANT TO RETRY?";
                            }
                            if (RetryButton)
                            {
                                RetryButton.SetActive(true);
                            }
                            if (NextLevelButton)
                            {

                                NextLevelButton.SetActive(false);
                            }
                        }
                    }
                    Cursor.visible = true;
                }
                else
                {
                    if (ResultBoard)
                    {
                        ResultBoard.SetActive(false);
                        Time.timeScale = 1;
                    }
                    Cursor.visible = false;
                }
            }
        }
    }
    public void NextLevel()
    {
        if (GS)
        {
            GS.LoadNextLevel();
        }
    }
    public void backButton()
    {
        Time.timeScale = 1;
        if (GS)
        {
            GS.BackfromGame();
        }
    }
    public void LevelComplete()
    {
        completed = true;
        Result(true);
    }
    public void setcoin(int amount)
    {
        coin += amount;
    }
    public void SetPauseScreen()
    {
        if(pauseScreen)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(ResultBoard)
                {
                    if(ResultBoard.active==false)
                    {
                        if (pauseScreen.active == false)
                        {
                            pauseScreen.SetActive(true);
                            Time.timeScale = 0;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        }
                        else
                        {
                            pauseScreen.SetActive(false);
                            Time.timeScale = 1;
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                        }
                    }
                }

            }

        }
    }
}

