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
    [SerializeField]
    Transform Landmark;
    [SerializeField]
    Vector3 originalPos;
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
        if(Landmark)
        {
            originalPos = Landmark.localPosition;
        }

    }
    public override void Shoot()
    {
        

    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            
            force = Mathf.Clamp(force, 0, maxforce);
            force += Time.deltaTime * 0.1f;
            if(Landmark)
            {
                Vector3 newPos = new Vector3(Landmark.localPosition.x, Landmark.localPosition.y, Landmark.localPosition.z + force);
                Landmark.localPosition = Vector3.Lerp(Landmark.localPosition,newPos,1*Time.deltaTime);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ReleaseRocket();
            
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
                Vector3 spawnPos = new Vector3(Landmark.position.x, Landmark.position.y + 20, Landmark.position.z);
                if(Landmark)
                {
                    var marker = (GameObject)Instantiate(Landmark.gameObject, Landmark.position, Landmark.rotation);
                    Destroy(marker, 3);
                    var bullet = (GameObject)Instantiate(bulletPrefab, spawnPos, transform.rotation);
                    if (bullet.GetComponent<Rigidbody>())
                    {

                        //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * force + player.GetRigidbody().velocity, ForceMode.Impulse);
                        bullet.GetComponent<Bullet>().setCurrentTeam(this.currentTeam);
                        bullet.GetComponent<Bullet>().setDamage(damage);
                    }
                }
               
            }
            currentAmmo--;
            Landmark.localPosition = originalPos;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
    private void OnDisable()
    {
        if(Landmark)
        {
            Landmark.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        if (Landmark)
        {
            Landmark.gameObject.SetActive(true);
        }
    }
}

