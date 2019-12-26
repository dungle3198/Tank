using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;
    [SerializeField]
    private Transform CamRotator;




    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
            CamRotator.transform.position = player.transform.position;
            CamRotator.rotation = Quaternion.Slerp(CamRotator.rotation, player.transform.rotation, 1);
        }
        Vector3 OffsetPos = new Vector3(0 + xOffset, 0+ yOffset, 0 + zOffset);
        transform.localPosition = OffsetPos;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
    void followPlayer()
    {
        if (player)
        {

            if (CamRotator)
            {
                CamRotator.position = player.transform.position;
                if (Time.timeScale != 0)
                {
                    CamRotator.transform.Rotate(player.getRotateVector());
                    //transform.LookAt(CamRotator);
                   
                    CamRotator.transform.position = player.transform.position;
                    
                }
            }


        }
    }
}