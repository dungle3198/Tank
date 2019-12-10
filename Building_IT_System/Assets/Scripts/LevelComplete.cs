using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    LevelSystem LS;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<LevelSystem>())
        {
            LS = FindObjectOfType<LevelSystem>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {

            LS.LevelComplete();
        }
    }
}
