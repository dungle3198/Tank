using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshr;
    [SerializeField]
    Collider col;
    [SerializeField]
    protected GameObject explosive_fx;
    [SerializeField]
    private HealthSphere health_sphere;
    [SerializeField]
    private AttackSphere attack_sphere;
    [SerializeField]
    private BulletSphere bullet_sphere;
    public void exploded()
    {
        if (explosive_fx)
        {
            explosive_fx.SetActive(true);
        }
        if (meshr && col)
        {
            if (meshr.enabled && col.enabled)
            {
                meshr.enabled = false;
                col.enabled = false;
            }
        }
       
        int x = Random.Range(0, 3);
        switch (x)
        {
            case 0:
                if (health_sphere)
                {
                    health_sphere.appear(); 
                }
                break;
            case 1:
                if (attack_sphere)
                {
                    attack_sphere.appear();
                }
                break;
            case 2:
                if (bullet_sphere)
                {
                    bullet_sphere.appear();
                }
                break;
        }
    }
}
