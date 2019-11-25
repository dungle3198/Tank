using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Bullet : Bullet {
    SphereCollider explosiveCollision;
    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rB = GetComponent<Rigidbody>();
            
        }
        if(GetComponent<SphereCollider>())
        {
            explosiveCollision = GetComponent<SphereCollider>();
        }


        Destroy(this.gameObject, 5);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(explosiveCollision)
        {
            explosiveCollision.enabled = false;
        }
       
        if (other.gameObject.GetComponent<Tank>())
        {
            Tank tank = other.gameObject.GetComponent<Tank>();
        }
        if (other.gameObject.GetComponent<Box>())
        {
            Box box = other.gameObject.GetComponent<Box>();
            box.exploded();
        }
        if (fX)
        {
            fX.SetActive(true);
        }
        if (rB)
        {
            rB.velocity = Vector3.zero;
        }
        if (mesh)
        {
            mesh.SetActive(false);
        }
        Destroy(this.gameObject, 2f);
    }

}
