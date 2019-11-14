using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    [SerializeField]
    GameObject messagebox;

    private void Start()
    {
        if(messagebox)
        {
            messagebox.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            if (messagebox)
            {
                messagebox.SetActive(true);
                Destroy(gameObject, 5f);
            }
            
        }
    }
   
}
