using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emplacement : MonoBehaviour
{
    [SerializeField]
    Gun gun1;
    [SerializeField]
    Gun gun2;
    [SerializeField]
    Gun gun3;
    [SerializeField]
    Gun gun4;
    [SerializeField]
    float interval = 5;
    [SerializeField]
    float shootTime = 0;
    [SerializeField]
    Cylinder cylinder1;
    [SerializeField]
    Cylinder cylinder2;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (cylinder1 && cylinder2)
            {
                cylinder1.rotate();
                cylinder2.rotate();
            }
            shootTime += Time.deltaTime;
            if (shootTime > interval)
            {
                if (gun1 && gun2 && gun3 && gun4)
                {
                    gun1.Shoot();
                    gun2.Shoot();
                    gun3.Shoot();
                    gun4.Shoot();
                    shootTime = 0;
                }
            }
        }
    }
}
