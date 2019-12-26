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
    [SerializeField] Image ReloadBar;
    [SerializeField] List<GameObject>listofAmmo;
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
            /*
            if (ammoText)
            {
                if (player.getGun())
                {
                    if (player.getGun().getcurrentAmmo() > 0)
                    {
                        ammoText.text = player.getGun().getcurrentAmmo().ToString() + " / " + player.getGun().getMaxAmmo().ToString();
                    }
                    else
                    {
                        ammoText.text = "Reloading";
                    }
                }
            }*/
            if (Ammobar)
            {
                if (player.getGun())
                {
                    if (player.getGun().getcurrentAmmo() > 0)
                    {
                        //Ammobar.fillAmount = player.getGun().getAmmoPercentage();
                        for (int i = 0; i < listofAmmo.Count - 1; i++)
                        {
                            if (i <= player.getGun().getcurrentAmmo())
                            {
                                if (i > 0)
                                {
                                    if(listofAmmo[i])
                                    {
                                        if(listofAmmo[i].activeSelf == false)
                                        {
                                            listofAmmo[i].SetActive(true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (listofAmmo[i])
                                {
                                    if (listofAmmo[i].activeSelf == true)
                                    {
                                        listofAmmo[i].SetActive(false);
                                    }
                                }
                            }
                            if(player.getGun().getcurrentAmmo() == 0)
                            {
                                if (ReloadBar)
                                {
                                    ReloadBar.fillAmount = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (listofAmmo[1])
                        {
                            if (listofAmmo[1].activeSelf == true)
                            {
                                listofAmmo[1].SetActive(false);
                                if (ReloadBar)
                                {
                                    ReloadBar.fillAmount = 0;
                                }
                            }
                        }
                        if(ReloadBar)
                        {
                            ReloadBar.fillAmount += Time.deltaTime * 1 / 3;
                        }
                    }
                }
            }
           
            if (healthText)
            {
                if (player.GetHealth())
                {
                    healthText.text = (player.GetHealth().getCurrentHealth()).ToString() + " / " + player.GetHealth().getMaxHealth().ToString();
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
