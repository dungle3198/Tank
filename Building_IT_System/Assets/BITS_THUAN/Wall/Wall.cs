using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
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
        movingTime += Time.deltaTime;
        if (movingTime > interval)
        {
            if (leftandright)
            {
                leftandright = false;
            }
            else
            {
                leftandright = true;
            }
            movingTime = 0;
        }
        if (leftandright)
        {
            transform.position = Vector3.Lerp(transform.position, pointA, 1 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pointB, 1 * Time.deltaTime);
        }
    }
}
