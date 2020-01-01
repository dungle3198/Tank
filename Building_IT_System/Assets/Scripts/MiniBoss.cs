using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy
{
    [SerializeField]
    protected GameObject tank_top;
    protected Quaternion targetRotation;
    [SerializeField]
    protected GameObject HUD;
    protected override void chasePlayer()
    {
        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < chasingDistance)
            {
                if(HUD)
                {
                    HUD.SetActive(true);
                }
                topRotation();
                gunFunction();
                if (distance > attackDistance)
                {
                    Vector3 desPos = new Vector3(player.transform.position.x + offSet, player.transform.position.y + offSet, player.transform.position.z + offSet);
                    agent.SetDestination(desPos);

                }
                else
                {
                    agent.velocity = Vector3.zero;
                    Vector3 directiontoFace = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
                    transform.rotation = Quaternion.LookRotation(directiontoFace);
                    
                }
            }
        }
    }
    protected virtual void topRotation()
    {
        if (tank_top && player)
        {
            Vector3 relativePos = player.transform.position - tank_top.transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            if (Quaternion.Angle(rotation, transform.rotation) <= 22)
            {
                targetRotation = rotation;
            }
            tank_top.transform.rotation = Quaternion.Slerp(tank_top.transform.rotation, targetRotation, 2 * Time.deltaTime);
        }
    }
}
