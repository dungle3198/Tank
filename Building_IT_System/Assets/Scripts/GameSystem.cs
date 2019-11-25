using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    int m_Gold = PlayerPrefs.GetInt("gold", 0);
    int m_Health = PlayerPrefs.GetInt("maxhealth", 0);
    int m_Damage = PlayerPrefs.GetInt("maxdamage", 0);
    int m_Ammo = PlayerPrefs.GetInt("maxammo", 0);
    int m_level = PlayerPrefs.GetInt("maxlevel", 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
