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
    [SerializeField]
    protected RectTransform HealthTransform;
    [SerializeField]
    protected float rate = 1;
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
           
            if (HealthBar)
            {
                HealthBar.sizeDelta = new Vector2(health.getHealthPercentage() * 100 * rate, HealthBar.sizeDelta.y);
                if (HealthTransform)
                {
                    HealthTransform.sizeDelta = Vector2.Lerp(HealthTransform.sizeDelta, HealthBar.sizeDelta, Time.deltaTime);
                }
            }
        }
    }
}
