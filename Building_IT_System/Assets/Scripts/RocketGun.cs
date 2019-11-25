using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGun : Gun
{
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
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward*shootingSpeed,ForceMode.Impulse);
                    bullet.GetComponent<Bullet>().setCurrentTeam(this.currentTeam);
                    bullet.GetComponent<Bullet>().setDamage(damage);
                }
            }
            currentAmmo--;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
}

