using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField]
    protected int Amount = 1;
    [SerializeField]
    GameObject modeling;
    protected AudioSource audio;
    [SerializeField]
    protected List<AudioClip> list;
    [SerializeField]
    protected LevelSystem LS;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<AudioSource>())
        {
            audio = GetComponent<AudioSource>();
            
        }
        if(GameObject.FindObjectOfType<LevelSystem>())
        {
            LS = GameObject.FindObjectOfType<LevelSystem>();
        }
        
    }
    private void Update()
    {
       
        transform.Rotate(1, 0, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            
            LS.setcoin(Amount);
            if(audio)
            {
                audio.PlayOneShot(list[0]);
            }
            Destroy(this.gameObject, 1);
        }
    }
    public void setCoin(int amount)
    {
        Amount = amount;
    }
}
