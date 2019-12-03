using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    [SerializeField]
    Material material;
    [SerializeField]
    Renderer rend;
    [SerializeField]
    Door door;
    bool not_opened = true;
    // Start is called before the first frame update
    void Start()
    {
        if (rend)
        {
            rend = GetComponent<Renderer>();
            rend.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (rend)
            {
                if (material) {  
                    rend.material = material;
                }
            }
            if (door)
            {
                if (not_opened)
                {
                    door.open();
                    not_opened = false;
                }
            }
        }
    }
}
