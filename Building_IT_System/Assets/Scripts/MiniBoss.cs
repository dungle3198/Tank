using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy
{


    // Update is called once per frame
    void Update()
    {

        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < chasingDistance)
            {
                if (distance > attackDistance)
                {
                 
                }
                else
                {
                   
                    Vector3 directiontoFace = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
                    transform.rotation = Quaternion.LookRotation(directiontoFace);
                    gunFunction();
                }
            }
        }
    }
}
