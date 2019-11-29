using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : Gun
{
    public GameObject fire;
    public override void Shoot()
    {
        if (fire)
        {
            fire.SetActive(true);
        }
        if (sound)
        {
            if (shootclip)
            {
                sound.clip = shootclip;
                sound.loop = true;
                if (!sound.isPlaying)
                {
                    sound.Play();
                    print("sound play");
                }
            }
        }

    }
    public void stopShooting()
    {
        if (fire)
        {
            fire.SetActive(false);
        }
        if (sound)
        {
            sound.Stop();
        }
    }
}


