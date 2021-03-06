﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected float damage;
    public float default_damage;
    protected Rigidbody rB;
    public Tank.Team currentTeam;
    public GameObject fX;
    public GameObject mesh;
    public AudioSource sound;
    public AudioClip explosive_clip;
    public GameSystem GS;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rB = GetComponent<Rigidbody>();
        }
        if (!GetComponent<AudioSource>())
        {
            sound = gameObject.AddComponent<AudioSource>();
            sound.playOnAwake = false;
        }
        if (FindObjectOfType<GameSystem>())
        {
            GS = FindObjectOfType<GameSystem>();
            if(currentTeam == Tank.Team.player)
            {
                damage += damage * GS.m_Damage;
            }
        }
        Destroy(this.gameObject, 5);
    }
    public void setCurrentTeam(Tank.Team team)
    {
        this.currentTeam = team;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.isTrigger == false)
        {
            if (other.GetComponent<Tank>())
            {
                Tank tank = other.GetComponent<Tank>();
                tank.applyDamge(damage, this.currentTeam);
            }
            if (other.GetComponent<Box>())
            {
                Box box = other.GetComponent<Box>();
                box.exploded();
            }
            explode();
        }
        
        explode();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tank>())
        {
            Tank tank = collision.gameObject.GetComponent<Tank>();
            tank.applyDamge(damage, this.currentTeam);
        }
        if (collision.gameObject.GetComponent<Box>())
        {
            Box box = collision.gameObject.GetComponent<Box>();
            box.exploded();
        }
        explode();
    }
    public void explode()
    {
        if (fX)
        {
            fX.SetActive(true);
        }
        if (rB)
        {
            rB.velocity = Vector3.zero;
        }
        if (mesh)
        {
            mesh.SetActive(false);
        }
        if(sound)
        {
            if (explosive_clip)
            {
                sound.clip = explosive_clip;
                sound.volume = 0.4f;
                sound.Play();
            }
        }
        if(explosive_clip)
        {
            Destroy(this.gameObject, explosive_clip.length);
        }
    }
        
    public void setDamage(float damage)
    {
        this.damage = damage;
    }

}
