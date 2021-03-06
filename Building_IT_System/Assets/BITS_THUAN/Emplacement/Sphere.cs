﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    Gun gun1;
    [SerializeField]
    Gun gun2;
    [SerializeField]
    Gun gun3;
    [SerializeField]
    Gun gun4;
    [SerializeField]
    float interval = 5;
    [SerializeField]
    float shootTime = 0;
    [SerializeField]
    Player player;
    [SerializeField]
    float Distance;
    [SerializeField]
    float AttackDistance = 35;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Distance = Vector3.Distance(transform.position, player.transform.position);
            if (Distance < AttackDistance)
            {
                shootTime += Time.deltaTime;
                if (shootTime > interval)
                {
                    gun1.Shoot();
                    gun2.Shoot();
                    gun3.Shoot();
                    gun4.Shoot();
                    shootTime = 0;
                }
            }
        }
    }
}
