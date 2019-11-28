using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    [SerializeField]
    Transform transformA;
    [SerializeField]
    Transform transformB;
    Vector3 pointA;
    Vector3 pointB;
    [SerializeField]
    bool leftandright = true; // left is true, right is fall 
    [SerializeField]
    float damage = 50;
    [SerializeField]
    float turnSpeed = 365f;
    // Start is called before the first frame update
    void Start()
    {
        pointA = transformA.position;
        pointB = transformB.position;
        transform.position = pointA;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (leftandright)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, Time.deltaTime);
            float distance = Vector3.Distance(transform.position, pointA);
            transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
            if (distance < 1.5f)
            {
                leftandright = false;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pointB, Time.deltaTime);
            float distance = Vector3.Distance(transform.position, pointB);
            transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
            if (distance < 1.5f)
            {
                leftandright = true;
            }
        }
         //transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
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
