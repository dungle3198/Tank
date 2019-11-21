using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Tank.Team currentTeam;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float shootingSpeed;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private int maxAmmo = 10;
    [SerializeField]
    private float damage = 10;

    [SerializeField]
    private AudioClip shootclip;
    [SerializeField]
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        if(GetComponent<AudioSource>())
        {
            sound = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float getAmmoPercentage()
    {
        float percentage = (float)currentAmmo / (float)maxAmmo;
        return percentage;
    }
    public void Shoot()
    {
        if (currentAmmo >0)
        {
            if(sound)
            {
                if(shootclip)
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
    public void setCurrentTeam(Tank.Team team)
    {
        this.currentTeam = team;
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3);
        currentAmmo = maxAmmo;
    }
    public void increaseMaxAmmo(int numAmmo)
    {
        this.maxAmmo += numAmmo;
    }
    public virtual void increaseDamage(float amountDamage)
    {
        this.damage += amountDamage;
    }
}
