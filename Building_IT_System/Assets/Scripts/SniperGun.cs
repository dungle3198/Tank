using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : Gun
{
    [SerializeField]
    protected LineRenderer line_r;
    [SerializeField]
    protected LayerMask layerMask;
    [SerializeField]
    protected Transform farScope;
    protected Vector3 hitScope;
    // Update is called once per frame
    void Update()
    {
        if(checkHitScan())
        {
            if (line_r)
            {
                line_r.SetPosition(0, transform.position);
                line_r.SetPosition(1, hitScope);
            }
        }
        else
        {
            if (line_r)
            {
                line_r.SetPosition(0, transform.position);
                hitScope = farScope.position;
                line_r.SetPosition(1, hitScope);
            }
        }
        

    }
    public override void Shoot()
    {
        if (currentAmmo > 0)
        {
            if (sound)
            {
                if (shootclip)
                {
                    sound.PlayOneShot(shootclip);
                }
            }
            if (bulletPrefab)
            {
                var bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
                if (bullet.GetComponent<Rigidbody>())
                {
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * shootingSpeed;
                    bullet.GetComponent<Bullet>().setCurrentTeam(this.currentTeam);
                    
                }
            }
            currentAmmo--;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
    bool checkHitScan()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            hitScope = hit.point;
            return true;
     
        }
        else
        {
            return false;
           
        }
    }
}
