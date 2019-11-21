using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emplacement : MonoBehaviour
{
    [SerializeField]
    float turnSpeed = 365f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
