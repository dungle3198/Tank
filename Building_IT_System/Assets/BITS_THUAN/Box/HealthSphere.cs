using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSphere : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshr;
    [SerializeField]
    Collider col;
    [SerializeField]
    float health = 50;

    void Start()
    {
        if (meshr && col)
        {
            if (meshr.enabled && col.enabled)
            {
                meshr.enabled = false;
                col.enabled = false;
            }
        }
    }
    public void appear()
    {
        if (meshr && col)
        {
            meshr.enabled = true;
            col.enabled = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {

            Player player = other.GetComponent<Player>();
            player.applyDamge(-health, Tank.Team.enemy);
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
