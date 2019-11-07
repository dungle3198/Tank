using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField]
    Vector3 pointA;
    [SerializeField]
    Vector3 pointB;
    [SerializeField]
    float interval =5;
    [SerializeField]
    float movingTime = 0;
    [SerializeField]
    bool upandown = true; // up is true, down is false

    [SerializeField]
    float damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        movingTime += Time.deltaTime;
        if (movingTime > interval)
        {
            if (upandown)
            {
                upandown = false;
            }
            else
            {
                upandown = true;
            }
            movingTime = 0;
        } 
        if (upandown)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, 1 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pointB, 1 * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            player.applyDamge(50,Tank.Team.enemy);
        }
    }
}
