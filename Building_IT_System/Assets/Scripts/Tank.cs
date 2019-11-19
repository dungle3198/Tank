using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public enum Team {player,enemy,neutral}
    [SerializeField]
    protected Team currentTeam;

    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Gun gun;
    [SerializeField]
    protected Health health;
    [SerializeField]
    protected GameObject explosive_fx;
    [SerializeField]
    protected AudioSource tankSound;
    [SerializeField]
    protected List<AudioClip> soundclip;
    protected Rigidbody rB;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if(!GetComponent<AudioSource>())
        {
            tankSound = gameObject.AddComponent<AudioSource>() as AudioSource;
            tankSound.playOnAwake = false;
        }
        if (GetComponent<Rigidbody>())
        {
            rB = GetComponent<Rigidbody>();
        }
        if (GetComponentInChildren<Gun>())
        {
            gun = GetComponentInChildren<Gun>();
            gun.setCurrentTeam(this.currentTeam);
        }
        if (GetComponent<Health>())
        {
            health = GetComponent<Health>();
        }
    }
    public virtual void applyDamge(float damage,Team oppositeTeam)
    {
        if(oppositeTeam != this.currentTeam && oppositeTeam != Team.neutral && this.currentTeam!= Team.neutral)
        {
            if(health)
            {
                health.applyDamage(damage);
                if(health.getCurrentHealth() <= 0)
                {
                    death();
                }
            }
        }
        
    }
    public virtual void commonDamage(float damage)
    {
        if (health)
        {
            health.applyDamage(damage);
        }
        print("fire damage");
    }
    public Team getCurrentTeam()
    {
        return this.currentTeam;
    }
    protected virtual void gunFunction()
    {
        if (gun)
        {
            gun.Shoot();
        }
    }
    public virtual void death()
    {
        if(health)
        {
            if(health.getCurrentHealth() <= 0)
            {
                if(explosive_fx)
                {
                    explosive_fx.SetActive(true);
                }
                if(tankSound)
                {
                    if(soundclip[1])
                    {
                        tankSound.PlayOneShot(soundclip[1]);
                    }
                }
                Destroy(gameObject, 1f);
            }
        }
    }
    public virtual void increaseDamage(float damage)
    {
        if (GetComponentInChildren<Gun>())
        {
            gun = GetComponentInChildren<Gun>();
            gun.increaseDamage(damage);
        }
    }
    public virtual void increaseMaxAmmo(int numAmmo)
    {
        if (GetComponentInChildren<Gun>())
        {
            gun = GetComponentInChildren<Gun>();
            gun.increaseMaxAmmo(numAmmo);
        }
    }
}
