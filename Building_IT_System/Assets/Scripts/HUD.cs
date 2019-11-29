using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text ammoText;

    public void healthChange(float health_value)
    {
     
        if(healthText)
        {
            healthText.text = health_value * 100 + " / 100" ;
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
