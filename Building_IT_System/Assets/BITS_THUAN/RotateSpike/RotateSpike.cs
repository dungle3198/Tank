using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpike : MonoBehaviour
{
    [SerializeField]
    float turnSpeed = 365f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
