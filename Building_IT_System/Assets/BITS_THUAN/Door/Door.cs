using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void open()
    {
        transform.Translate((Vector3.down*6));
    }
}
