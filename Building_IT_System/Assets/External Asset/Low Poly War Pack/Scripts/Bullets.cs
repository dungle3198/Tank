using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float destroyTime;

    public Collider[] toIgnore;

    public GameObject particles;

    [HideInInspector]
    public bool instantiateParticles = false;

    void Start()
    {
        StartCoroutine(AutoDestroy(6));
        toIgnore = GetComponents<Collider>();
    }

    void OnCollisionEnter(Collision other)
    {
        foreach (Collider item in toIgnore)
        {
            if (instantiateParticles && particles != null)
            {
                Instantiate(particles, other.contacts[0].point, new Quaternion(0, 0, 0, 0));
            }

            else
            {
                AutoDestroy(1);
            }
        }
    }

    IEnumerator ExpiryDate(float deathTime )
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }

    IEnumerator AutoDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
