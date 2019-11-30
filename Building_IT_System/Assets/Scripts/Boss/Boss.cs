using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Boss : Enemy
{
    enum stage { _1stage, _2stage, _3stage };
    enum substage { Move, Stop, Fire, Rotate,shootAWP,suprisedAttack }
    [SerializeField]
    substage stage_status;
    [SerializeField]
    float wait_time;
    [SerializeField]
    FireGun bossgun;
    [SerializeField]
    Animator anime;
    IDictionary<substage, Action> first_stage_actions = new Dictionary<substage, Action>();
    IDictionary<substage, Action> second_stage_actions = new Dictionary<substage, Action>();
    protected override void Start()
    {
        base.Start();

        //first phase
        first_stage_actions.Add(substage.Move, MoveToPlayer);
        first_stage_actions.Add(substage.Stop, Stop);
        first_stage_actions.Add(substage.Fire, Fire);
        first_stage_actions.Add(substage.Rotate, LookToPlayer);

        //second phase
        second_stage_actions.Add(substage.Move, MoveToPlayer);
        second_stage_actions.Add(substage.Stop, Stop);
        second_stage_actions.Add(substage.Fire, Fire);
        second_stage_actions.Add(substage.Rotate, LookToPlayer);
        second_stage_actions.Add(substage.shootAWP, LookToPlayer);
        second_stage_actions.Add(substage.suprisedAttack, surprisedAttack);
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
            if (health.getHealthPercentage() > 75)
            {
                first_stage_actions[stage_status]();
            }
            else if(health.getHealthPercentage() < 75 && health.getHealthPercentage() > 25)
            {
                second_stage_actions[stage_status]();
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
               stage_status = substage.Stop;
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
            stage_status = substage.Fire;
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
            stage_status = substage.Rotate;
        }
    }
    protected void LookToPlayer()
    {
        if (player)
        {
            Vector3 directiontoFace = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
            transform.rotation = Quaternion.LookRotation(directiontoFace);
        }
        stage_status = substage.Move;
    }
    protected void shootAWP()
    {
        if (player)
        {
            Vector3 directiontoFace = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
            transform.rotation = Quaternion.LookRotation(directiontoFace);
        }
        gunFunction();
        if(wait_time > 3)
        {
          stage_status = substage.suprisedAttack;
        }
    }
    protected void surprisedAttack()
    {
        rB.velocity = transform.forward * 40;
        if (wait_time > 2)
        {
            stage_status = substage.Rotate;
        }
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

