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
    private GameSystem GS;

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
            
        }
        if(FindObjectOfType<LevelSystem>())
        {
            LS = FindObjectOfType<LevelSystem>();
        }
        if(FindObjectOfType<GameSystem>())
        {
            GS = FindObjectOfType<GameSystem>();
            if(health)
            {
                print("i gain health");
                float newMaxHealth = health.getMaxHealth() + GS.m_Health * 25;
                health.setMaxHealth(newMaxHealth);
            }
            transform.position = GS.spawning(this.transform.position);
        }
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            movement();
            gunFunction();
            switchGun();
        }
       
    }
    void movement()
    {
        if (rB)
        {
            float x = Input.GetAxis("Horizontal") + Input.GetAxis("Mouse X");
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
        /*if(Upperbody)
        {
            float x = Input.GetAxis("Mouse X");
            Upperbody.Rotate(0, 0,x);
        }*/
    }
    protected override void gunFunction()
    {
        if (gun)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                gun.Shoot();
               
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
              
                death();
            }
        }

    }
    public override void commonDamage(float damage)
    {
        if (health)
        {
            health.applyDamage(damage);

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
           
        }
        if (gun)
        {
            gun.fastReload();
         
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
