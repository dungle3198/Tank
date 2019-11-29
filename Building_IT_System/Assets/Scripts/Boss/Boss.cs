using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Boss : Enemy
{
    enum stage { _1stage, _2stage, _3stage };
    enum first_substage { Move, Stop, Fire, Rotate }
    [SerializeField]
    first_substage firststage_status;
    [SerializeField]
    float wait_time;
    [SerializeField]
    FireGun bossgun;
    [SerializeField]
    Animator anime;
    IDictionary<first_substage, Action> first_stage_actions = new Dictionary<first_substage, Action>();
    protected override void Start()
    {
        base.Start();
        first_stage_actions.Add(first_substage.Move, MoveToPlayer);
        first_stage_actions.Add(first_substage.Stop, Stop);
        first_stage_actions.Add(first_substage.Fire, Fire);
        first_stage_actions.Add(first_substage.Rotate, LookToPlayer);
        if (GetComponentInChildren<FireGun>())
        {
            bossgun = GetComponentInChildren<FireGun>();
        }
        if (GetComponentInChildren<Animator>())
        {
            anime = GetComponentInChildren<Animator>();
        }
    }
    protected override void Update()
    {
        if (health)
        {
            if (health.getCurrentHealth() > 0)
            {
                first_stage_actions[firststage_status]();
            }
            else
            {

            }
        }

    }
    protected void MoveToPlayer()
    {
        if (player)
        {
            Vector3 desPos = new Vector3(player.transform.position.x + offSet, player.transform.position.y + offSet, player.transform.position.z + offSet);
            distance = Vector3.Distance(transform.position, desPos);
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
            if (agent)
            {
                if (agent.isStopped == true)
                {
                    agent.isStopped = false;
                }
                agent.SetDestination(desPos);
                if (anime)
                {
                    anime.SetFloat("speed", 1);
                }
            }

            if (distance < 5)
            {
                if (tankSound)
                {
                    if (tankSound.isPlaying)
                    {
                        tankSound.Stop();
                        tankSound.loop = false;
                    }
                }
                if (anime)
                {
                    anime.SetFloat("speed", 0);
                }
                firststage_status = first_substage.Stop;
            }
        }
    }
    protected void Stop()
    {
        if (agent)
        {
            agent.isStopped = true;
        }
        wait_time += Time.deltaTime;
        if (wait_time > 1)
        {
            wait_time = 0;
            firststage_status = first_substage.Fire;
        }
    }
    protected void Fire()
    {
        wait_time += Time.deltaTime;
        bossgun.Shoot();
        transform.Rotate(0, 5, 0);
        if (tankSound)
        {
            if (!tankSound.isPlaying)
            {
                tankSound.clip = soundclip[1];
                tankSound.loop = false;
                tankSound.volume = 0.5f;
                tankSound.Play();

            }
        }
        if (anime)
        {
            anime.SetInteger("rotate", 1);
        }
        if (wait_time > 3)
        {
            if (anime)
            {
                anime.SetInteger("rotate", 0);
            }
            bossgun.stopShooting();
            wait_time = 0;
            firststage_status = first_substage.Rotate;
        }
    }
    protected void LookToPlayer()
    {
        if (player)
        {
            Vector3 directiontoFace = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
            transform.rotation = Quaternion.LookRotation(directiontoFace);
        }
        firststage_status = first_substage.Move;
    }
    public override void death()
    {
        base.death();
        if (anime)
        {
            anime.SetBool("death", true);
        }
    }
}

