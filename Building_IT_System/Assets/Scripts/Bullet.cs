using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private Rigidbody rB;
    public Tank.Team currentTeam;
    public GameObject fX;
    public GameObject mesh;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rB = GetComponent<Rigidbody>();
        }
       
        Destroy(this.gameObject, 5);
    }
    public void setCurrentTeam(Tank.Team team)
    {
        this.currentTeam = team;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Tank>())
        {
            Tank tank = other.GetComponent<Tank>();
            tank.applyDamge(damage, this.currentTeam);
        }
        if (other.GetComponent<Box>())
        {
            Box box = other.GetComponent<Box>();
            box.exploded();
        }
        if (fX)
        {
            fX.SetActive(true);
        }
        if(rB)
        {
            rB.velocity = Vector3.zero;
        }
        if(mesh)
        {
            mesh.SetActive(false);
        }
        Destroy(this.gameObject, 0.4f);
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }

}
