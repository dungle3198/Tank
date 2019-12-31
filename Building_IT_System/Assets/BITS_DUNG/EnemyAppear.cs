using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    [SerializeField]
    GameObject container;
    [SerializeField]
    Player player;
    [SerializeField]
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        if(mesh)
        {
            mesh.enabled = false;
        }
        if(container)
        {
            container.SetActive(false);
        }
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 0.25f, transform.position.z);
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
           if(container)
            {
                container.SetActive(true);
            }
        }
    }

}