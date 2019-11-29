using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField]
    float turnSpeed = 365f;
    public void rotate()
    {
        transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
    }
}
