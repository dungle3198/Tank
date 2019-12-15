using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        }
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
                                ResultText.text = gameObject.scene.name +
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
                                ResultText.text = gameObject.scene.name + "\nYOU ARE DEATH, YOU WANT TO RETRY?";
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
                }
                else
                {
                    if (ResultBoard)
                    {
                        ResultBoard.SetActive(false);
                        Time.timeScale = 1;
                    }
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
                        }
                        else
                        {
                            pauseScreen.SetActive(false);
                            Time.timeScale = 1;
                        }
                    }
                }

            }

        }
    }
}

