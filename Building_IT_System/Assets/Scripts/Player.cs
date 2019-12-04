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

    [SerializeField]
    List<Gun> guns;
    [SerializeField]
    int currentGunIndex;
    [SerializeField]
    private Transform Upperbody;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(FindObjectOfType<HUD>())
        {
            hud = FindObjectOfType<HUD>();
            hud.healthChange(health.getHealthPercentage());
            hud.ammoChange(gun.getcurrentAmmo());
        }
        if(FindObjectOfType<LevelSystem>())
        {
            LS = FindObjectOfType<LevelSystem>();
        }
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        gunFunction();
        switchGun();
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

            if(rB.velocity.x != 0 || rB.velocity.z != 0 )
            {
                if(tankSound)
                {
                    if(!tankSound.isPlaying)
                    {
                        tankSound.clip = soundclip[0];
                        tankSound.loop = true;
                        tankSound.volume = 0.25f;
                        tankSound.volume = 0.25f;
                        tankSound.Play();
       
                    }
                }
            }
            else
            {
                if (tankSound)
                {
                    if (tankSound.isPlaying)
                    {
                        tankSound.Stop();
                        tankSound.loop = false;
                    }
                }
            }
        }
        if(Upperbody)
        {
            //float x = Input.GetAxis("Mouse X");
            //Upperbody.Rotate(0, 0,x);
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
                    hud.ammoChange(gun.getcurrentAmmo());
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
            death();
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
                this.GetComponent<Player>().enabled = false;
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
                hud.ammoChange(gun.getcurrentAmmo());
            }
        }
        this.GetComponent<Player>().enabled = true;
    }
    public Rigidbody GetRigidbody()
    {
        return rB;
    }
    public void switchGun()
    {
        if(guns.Count > 0)
        {
            
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                gun.gameObject.SetActive(false);
                currentGunIndex++;
                if(currentGunIndex > guns.Count - 1)
                {
                    currentGunIndex = 0;
                }
                gun = guns[currentGunIndex];
                gun.gameObject.SetActive(true);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                gun.gameObject.SetActive(false);
                currentGunIndex--;
                if (currentGunIndex < 0)
                {
                    currentGunIndex = guns.Count - 1;
                }
                gun = guns[currentGunIndex];
                gun.gameObject.SetActive(true);
            }
            
        }
    }
}
