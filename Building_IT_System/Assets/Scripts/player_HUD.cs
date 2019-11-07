using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_HUD : MonoBehaviour
{
    public Slider healthBar;

    [SerializeField] private Slider ammoBar;
    [SerializeField] private int mega;

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
