﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy :AI
{
    [SerializeField]
    protected Player player;
    [SerializeField]
    protected float distance;
    [SerializeField]
    protected float offSet;
    [SerializeField]
    protected NavMeshAgent agent;

    [SerializeField]
    protected float chasingDistance = 25;
    [SerializeField]
    protected float attackDistance = 15;

    [SerializeField]
    float shootTime = 0;
    [SerializeField]
    float interval = 1.5f;
    protected override void Start()
    {
        base.Start();
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
        }
        if(GetComponent<NavMeshAgent>())
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
    protected virtual void Update()
    {
        if(health)
        {
            if(health.getCurrentHealth()>0)
            {
                chasePlayer();
            }
            else
            {
                
            }
        }
        
    }
    protected void chasePlayer()
    {
        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < chasingDistance)
            {
                if (distance > attackDistance)
                {
                    Vector3 desPos = new Vector3(player.transform.position.x + offSet, player.transform.position.y + offSet, player.transform.position.z + offSet);
                    agent.SetDestination(desPos);
                    if (agent.velocity.x != 0 || agent.velocity.z != 0)
                    {
                        if (tankSound)
                        {
                            if (!tankSound.isPlaying)
                            {
                                tankSound.clip = soundclip[0];
                                tankSound.loop = true;
                                tankSound.volume = 0.5f;
                                tankSound.Play();

                            }
                        }
                    }
                    else
                    {
                        if (tankSound)
                        {
                            if (tankSound.isPlaying)
                            {
                                tankSound.Stop();
                                tankSound.loop = false;
                            }
                        }
                    }
                }
                else
                {
                    agent.velocity = Vector3.zero;
                    Vector3 directiontoFace = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
                    transform.rotation = Quaternion.LookRotation(directiontoFace);
                    gunFunction();
                }
            }
        }
    }
  
    protected override void gunFunction()
    {
        if(shootTime < Time.time)
        {
            base.gunFunction();
            shootTime = Time.time + interval;
        }
        
    }



}
