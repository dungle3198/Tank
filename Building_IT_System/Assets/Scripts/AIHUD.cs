using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIHUD : MonoBehaviour
{
    [SerializeField]
    protected RectTransform HealthBar;
    [SerializeField]
    protected Health health;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponentInParent<Health>())
        {
            health = GetComponentInParent<Health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health)
        {
            HealthBar.sizeDelta = new Vector2(health.getHealthPercentage()*100*4, HealthBar.sizeDelta.y);
        }
    }
}
