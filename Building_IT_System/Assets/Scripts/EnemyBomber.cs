using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : Enemy
{
    [SerializeField]
    protected float selfdamage = 30;
    [SerializeField]
    protected SphereCollider explosiveCol;
    protected override void chasePlayer()
    {
        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < chasingDistance)
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
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            print("i hit you");
            if(explosiveCol)
            {
                explosiveCol.enabled = true;
            }
            applyDamge(health.getCurrentHealth(), Team.player);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            other.GetComponent<Player>().applyDamge(selfdamage,Team.enemy);
        }
    }
}
