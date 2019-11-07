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
        }
        Vector3 OffsetPos = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z + zOffset);
        transform.position = OffsetPos;
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
                CamRotator.Rotate(player.getRotateVector());
            }
            
            
        }
    }
}
