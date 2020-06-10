using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    // Enemy Attack Specification
    public float attackTerm;

    // Inner Active
    private EnemyAttacks ea;

    // Start is called before the first frame update
    void Start()
    {
        ea = this.transform.GetComponent<EnemyAttacks>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Attack()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackTerm);
            ea.SpawnProjectileAttack();
        }
    }
}
