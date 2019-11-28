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
    }

    // Update is called once per frame
    void Update()
    {
        
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
        spawning();
        Result(false);
        if (RetryButton)
        {
            RetryButton.SetActive(false);
        }
    }
    public void Menu()
    {
       
    }
    public void Result(bool on)
    {
        Cursor.lockState = CursorLockMode.None;
        if (on)
        {
            if (ResultBoard)
            {
                print("hello");
                ResultBoard.SetActive(true);
                Time.timeScale = 0;
                if(completed)
                {
                    if(ResultText)
                    {
                        ResultText.text = "YOU HAVE COMPLETED THE LEVEL!";
                    }
                   
                }
                else
                {
                    if (ResultText)
                    {
                        ResultText.text = "YOU ARE DEATH, YOU WANT TO RETRY?";
                    }
                    if (RetryButton)
                    {
                        RetryButton.SetActive(true);
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
