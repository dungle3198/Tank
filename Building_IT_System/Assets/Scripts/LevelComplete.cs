using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    GameSystem GS;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<GameSystem>())
        {
            GS = FindObjectOfType<GameSystem>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            GS.LoadNextLevel();
        }
    }
}
