using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Tank.Team currentTeam;
    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected float shootingSpeed;
    [SerializeField]
    protected int currentAmmo;
    [SerializeField]
    protected int maxAmmo = 10;
    [SerializeField]
    protected float damage = 10;


    [SerializeField]
    protected AudioClip shootclip;
    [SerializeField]
    protected AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        if(GetComponent<AudioSource>())
        {
            sound = GetComponent<AudioSource>();
        }
        
    }
    public float getAmmoPercentage()
    {
        float percentage = (float)currentAmmo / (float)maxAmmo;
        return percentage;
    }
    public virtual void Shoot()
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
                    //bullet.GetComponent<Bullet>().setDamage(damage);
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
    public virtual IEnumerator Reload()
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
    public virtual void fastReload()
    {
        currentAmmo = maxAmmo;
    }
    public int getcurrentAmmo()
    {
        return currentAmmo;
    }
}
