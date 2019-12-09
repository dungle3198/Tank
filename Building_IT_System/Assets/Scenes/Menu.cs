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
    [SerializeField]
    Text UpgradeHealthText;
    [SerializeField]
    Text UpgradeDamageText;
    [SerializeField]
    Text UpgradeAmmoText;
    public Text LevelText; 
    private void Update()
    {
        if(GS)
        {
            if(LevelText)
                LevelText.text =(GS.currentLevelIndex + 1).ToString();

            if (UpgradeHealthText)
                UpgradeHealthText.text = GS.m_Health.ToString();

            if (UpgradeDamageText)
                UpgradeDamageText.text = GS.m_Damage.ToString();

            if (UpgradeAmmoText)
                UpgradeAmmoText.text = GS.m_Ammo.ToString();

        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
