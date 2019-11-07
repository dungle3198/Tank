using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField]private Slider healthBar;


    [SerializeField]private Slider ammoBar;

    public void healthChange(float health_value)
    {
        if (healthBar != null)
        {
            healthBar.value = health_value;
        }
    }
    public void ammoChange(float ammo_value)
    {
        if (healthBar != null)
        {
            ammoBar.value = ammo_value;
        }
    }
}
