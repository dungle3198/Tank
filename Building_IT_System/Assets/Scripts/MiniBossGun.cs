using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossGun : Gun
{
    [SerializeField]
    Player player;
    void Start()
    {
        currentAmmo = maxAmmo;
        if (GetComponent<AudioSource>())
        {
            sound = GetComponent<AudioSource>();
        }
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
        }

    }
    public override void Shoot()
    {
        if (sound)
        {
            if (shootclip)
            {
                sound.PlayOneShot(shootclip);
            }
        }
        if (bulletPrefab && player)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, player.transform.position, transform.rotation);
            if (bullet.GetComponent<Rigidbody>())
            {
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * shootingSpeed;
                bullet.GetComponent<Bullet>().setCurrentTeam(this.currentTeam);
                bullet.GetComponent<Bullet>().setDamage(damage);
            }
        }
       
    }
}
