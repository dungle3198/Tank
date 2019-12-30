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
    Text HealthCost;
    [SerializeField]
    Text UpgradeDamageText;
    [SerializeField]
    Text DamageCost;
    [SerializeField]
    Text UpgradeAmmoText;
    [SerializeField]
    Text AmmoCost;
    [SerializeField]
    Text GoldText;
    [SerializeField]
    GameObject menu;
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

            if (HealthCost)
                HealthCost.text = GS.getCost(1).ToString();
            if (DamageCost)
                DamageCost.text = GS.getCost(2).ToString();
            if (AmmoCost)
                AmmoCost.text = GS.getCost(3).ToString();
            if(GoldText)
            {
                GoldText.text = GS.m_Gold.ToString();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackButtonFromGame()
    {
        if(menu)
        {
            menu.SetActive(true);
        }
    }
}
