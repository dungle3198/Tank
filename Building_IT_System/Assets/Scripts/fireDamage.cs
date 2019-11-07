using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireDamage : MonoBehaviour
{
    [SerializeField]
    float damagePerSecond = 1;
    float damagingTime = 0;
    float interval = 0.25f;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Tank>())
        {
            Tank tank = other.GetComponent<Tank>();
            if (damagingTime < Time.time)
            {
                tank.commonDamage(damagePerSecond);
                damagingTime = Time.time + interval;
            }
        }

    }
}
