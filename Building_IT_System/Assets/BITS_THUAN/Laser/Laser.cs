using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    float interval = 5;
    [SerializeField]
    float appearTime = 0;
    [SerializeField]
    float damage = 50;
    [SerializeField]
    MeshRenderer meshr;
    [SerializeField]
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        if (meshr && col)
        {
            meshr.enabled = false;
            col.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        appearTime += Time.deltaTime;
        if (appearTime > interval)
        {
            if (meshr.enabled && col.enabled)
            {
                meshr.enabled = false;
                col.enabled = false;
            }
            else
            {
                meshr.enabled = true;
                col.enabled = true;
            }
            appearTime = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            player.applyDamge(damage, Tank.Team.enemy);
        }
    }
}
