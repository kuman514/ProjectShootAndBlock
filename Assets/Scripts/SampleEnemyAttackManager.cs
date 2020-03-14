using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyAttackManager : MonoBehaviour
{
    // Enemy Attack Specification
    public float attackTerm;

    // Inner Active
    private float attackTimer;
    private EnemyAttacks ea;

    // Start is called before the first frame update
    void Start()
    {
        ea = this.transform.GetComponent<EnemyAttacks>();
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ReduceTimer();
        Attack();
    }

    void ReduceTimer()
    {
        if(attackTimer < attackTerm)
        {
            attackTimer += Time.deltaTime;
        }
    }

    void Attack()
    {
        if(attackTimer >= attackTerm)
        {
            ea.SpawnProjectileAttack();
            attackTimer = 0;
        }
    }
}
