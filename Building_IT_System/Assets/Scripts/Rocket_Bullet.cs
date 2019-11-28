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
        if(GetComponentInChildren<SphereCollider>())
        {
            explosiveCollision = GetComponent<SphereCollider>();
        }
        if (!GetComponent<AudioSource>())
        {
            sound = gameObject.AddComponent<AudioSource>();
            sound.playOnAwake = false;
        }

        Destroy(this.gameObject, 5);
    }
    private void Update()
    {
        transform.Rotate(1, 0, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(!other.gameObject.GetComponent<Bullet>())
        {
            if (explosiveCollision)
            {
                explosiveCollision.enabled = true;
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
            explode();
        }
    }

}
