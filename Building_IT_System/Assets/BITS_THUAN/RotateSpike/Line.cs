using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    float damage = 50;
    [SerializeField]
    float interval = 1;
    [SerializeField]
    float stayTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            player.applyDamge(damage, Tank.Team.enemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        stayTime += Time.deltaTime;
        if (stayTime > interval)
        {
            if(other.GetComponent<Player>())
            {
                Player player = other.GetComponent<Player>();
                player.applyDamge(damage, Tank.Team.enemy);
            }
           
            stayTime = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        stayTime = 0;
    }
}
