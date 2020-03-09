using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Object Specification
    public float curHP;
    public float maxHP;

    // Inner Active
    // None Yet

    // References
    public GameObject destroyWhenHPIs0;

    // Start is called before the first frame update
    void Start()
    {
        HPUpdate(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(curHP <= 0)
        {
            Destroy(destroyWhenHPIs0);
        }
    }

    void HPUpdate(float amount)
    {
        curHP += amount;

        if (curHP < 0)
        {
            curHP = 0;
        }
        else if (curHP > maxHP)
        {
            curHP = maxHP;
        }
    }

    public void Damage(float dmg)
    {
        HPUpdate(-dmg);
    }

    public void Heal(float heal)
    {
        HPUpdate(heal);
    }
}
