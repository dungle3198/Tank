using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    protected GameObject explosive_fx;
    [SerializeField]
    float damage = 50;
    [SerializeField]
    AudioSource audio;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    GameObject model;
    private void Start()
    {
        if(GetComponent<AudioSource>())
        {
            audio = GetComponent<AudioSource>();
            audio.loop = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (explosive_fx)
            {
                explosive_fx.SetActive(true);
            }
            Destroy(this.gameObject);
            Player player = other.GetComponent<Player>();
            player.applyDamge(damage, Tank.Team.enemy);
            if(this.audio && clip)
            {
                audio.PlayOneShot(clip, 0.5f);
            }
            if(model)
            {
                model.SetActive(false);
            }
            if (this.transform.parent.gameObject)
            {
                Destroy(this.transform.parent.gameObject, 6f);
            }
        }
    }
}
