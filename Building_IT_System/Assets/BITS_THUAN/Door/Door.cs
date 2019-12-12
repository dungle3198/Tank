using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    int size = 6;
    public void open()
    {
        transform.Translate((Vector3.down*size));
    }
}
