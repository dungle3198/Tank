using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text ammoText;
    [SerializeField] Image Healthbar;
    [SerializeField] Image Ammobar;

    Player player;
    private void Start()
    {
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
        }
    }
    public void healthChange(float health_value)
    {
     
        if(healthText)
        {
            healthText.text = health_value * 100 + " / 100" ;
        }
    }
    private void Update()
    {
        if (player)
        {
            if (ammoText)
            {
                if (player.getGun())
                {
                    if (player.getGun().getcurrentAmmo() > 0)
                    {
                        ammoText.text = player.getGun().getcurrentAmmo().ToString();
                    }
                    else
                    {
                        ammoText.text = "Reloading";
                    }
                }
            }
            if (Ammobar)
            {
                if (player.getGun())
                {
                    Ammobar.fillAmount = player.getGun().getAmmoPercentage();
                }
            }
            if (healthText)
            {
                if (player.GetHealth())
                {
                    healthText.text = (player.GetHealth().getHealthPercentage() * 100).ToString() + " /100";
                }
            }
            if (Healthbar)
            {
                if (player.GetHealth())
                {
                    Healthbar.fillAmount = player.GetHealth().getHealthPercentage();
                }
            }
        }
    }
    public void ammoChange(float ammo_value)
    {

        if (ammoText)
        {
            if (ammo_value == 0)
            {
                ammoText.text = "Reloading";
            }
            else
            {
                ammoText.text = ammo_value + "";
            }
        }
    }
}
