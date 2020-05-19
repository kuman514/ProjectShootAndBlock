using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlateMethods : MonoBehaviour
{
    // specification
    public float healPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(!collision.transform.gameObject.CompareTag("Player"))
        {
            return;
        }

        HealthManager playerHP = collision.transform.gameObject.GetComponent<HealthManager>();
        if(playerHP != null)
        {
            playerHP.Heal(healPerSecond * Time.deltaTime);
        }
    }
}
