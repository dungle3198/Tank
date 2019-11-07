using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSphere : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshr;
    [SerializeField]
    Collider col;
    [SerializeField]
    float amountAmmo = 10;
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
        if (other.GetComponent<Tank>())
        {
            Player player = other.GetComponent<Player>();
            player.increaseMaxAmmo(10);
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
