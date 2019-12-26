using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour
{
    [SerializeField]
    GameObject messagebox;
    public float distance;
    public float appearDistance = 10;
    public string message;
    [SerializeField] Player player;
    [SerializeField] SphereCollider col;
    [SerializeField] Text messageBox; 
    [SerializeField] float Timer = 10f;
    private void Start()
    {
        if (GetComponentInChildren<Text>())
        {
            messageBox = GetComponentInChildren<Text>();
            messageBox.text = message;

        }
        if (messagebox)
        {
            messagebox.SetActive(false);
        }
        if(FindObjectOfType<Player>())
        {
            player = FindObjectOfType<Player>();
        }
        if(GetComponent<SphereCollider>())
        {
            col = GetComponent<SphereCollider>();
            col.enabled = false;
        }
       
    }
    private void Update()
    {
        if(player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance <= appearDistance)
            {
                if (messagebox)
                {
                    messagebox.SetActive(true);
                    Destroy(gameObject, Timer );
                }
            }
        }
    }
   
   
}
