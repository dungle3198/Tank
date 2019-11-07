using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    [SerializeField]
    Vector3 pointA;
    [SerializeField]
    Vector3 pointB;
    [SerializeField]
    float interval = 5;
    [SerializeField]
    float movingTime = 0;
    [SerializeField]
    bool leftandright = true; // left is true, right is fall 
    [SerializeField]
    float damage = 50;

    float turnSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (leftandright)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, 5 * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, pointA);
            if (distance < 0.125f)
            {
                leftandright = false;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pointB, 5 * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, pointB);
            if (distance < 0.125f)
            {
                leftandright = true;
            }
        }
         transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
