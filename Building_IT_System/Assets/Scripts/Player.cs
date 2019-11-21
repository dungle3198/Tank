using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
  
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Vector3 RotateVector;
    [SerializeField]
    private HUD hud;
    [SerializeField]
    private LevelSystem LS;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(FindObjectOfType<HUD>())
        {
            hud = FindObjectOfType<HUD>();
        }
        if(FindObjectOfType<LevelSystem>())
        {
            LS = FindObjectOfType<LevelSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        gunFunction();
    }
    void movement()
    {
        if (rB)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float yvel = rB.velocity.y;
            float xvel = rB.velocity.x;
            Vector3 MoveVector = transform.forward*z*speed+transform.up*rB.velocity.y;
            this.RotateVector = new Vector3(0, x * rotateSpeed, 0);
            transform.Rotate(RotateVector);
            rB.velocity = MoveVector;
        }
    }
    protected override void gunFunction()
    {
        if (gun)
        {
            if (Input.GetButtonDown("Jump"))
            {
                gun.Shoot();
                if (hud)
                {
                    hud.ammoChange(gun.getAmmoPercentage());
                }
            }
        }
    }
    public Vector3 getRotateVector()
    {
        return this.RotateVector;
    }
    public override void applyDamge(float damage, Team oppositeTeam)
    {
        if (oppositeTeam != this.currentTeam && oppositeTeam != Team.neutral && this.currentTeam != Team.neutral)
        {
            if (health)
            {
                health.applyDamage(damage);
                if(hud)
                {
                    hud.healthChange(health.getHealthPercentage());
                }
                death();
            }
        }

    }
    public override void commonDamage(float damage)
    {
        if (health)
        {
            health.applyDamage(damage);
            if (hud)
            {
                hud.healthChange(health.getHealthPercentage());
            }
            print("fire damage");
        }
    }
    public override void death()
    {
        if (health)
        {
            if (health.getCurrentHealth() <= 0)
            {
                if (explosive_fx)
                {
                    explosive_fx.SetActive(true);
                }
                if (tankSound)
                {
                    if (soundclip[1])
                    {
                        tankSound.PlayOneShot(soundclip[1]);
                    }
                }
                if (LS)
                {
                    print("hello");
                    LS.Result(true);
                }
            }
        }
    }
    public void Respawn()
    {
        if(health)
        {
            health.GainFullHealth();
            if (hud)
            {
                hud.healthChange(health.getHealthPercentage());
            }
        }
        if (gun)
        {
            gun.fastReload();
            if (hud)
            {
                hud.ammoChange(gun.getAmmoPercentage());
            }
        }
    }
}
