using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_player : MonoBehaviour
{
    [SerializeField]
    Vector3 checkPos = new Vector3(0, 0, 0);
    [SerializeField]
    GameSystem GS;
    [SerializeField]
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        checkPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        if(FindObjectOfType<GameSystem>())
        {
            GS = FindObjectOfType<GameSystem>();
        }
        if(GetComponent<MeshRenderer>())
        {
            mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            if (GS)
            {
                GS.setRespawnPos(checkPos);
            }

        }
    }
}
