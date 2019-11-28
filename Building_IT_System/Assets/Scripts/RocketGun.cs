using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketGun : Gun
{
    [SerializeField]
    float force;
    [SerializeField]
    Player player;
    [SerializeField]
    float maxforce;
    [SerializeField]
    RectTransform forceBar;
    void Start()
    {
        currentAmmo = maxAmmo;
        if (GetComponent<AudioSource>())
        {
            sound = GetComponent<AudioSource>();
        }
        if(GetComponentInParent<Player>())
        {
            player = GetComponentInParent<Player>();
        }

    }
    public override void Shoot()
    {
        

    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            
            force = Mathf.Clamp(force, 5, maxforce);
            force += Time.deltaTime * 4;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ReleaseRocket();
            force = 5;
        }
        if (forceBar)
        {
            forceBar.sizeDelta = new Vector2(force / maxforce * 400, forceBar.sizeDelta.y);
        }
    }
    public void ReleaseRocket()
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
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * force + player.GetRigidbody().velocity, ForceMode.Impulse);
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

