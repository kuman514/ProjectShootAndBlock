using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyAttackManager : MonoBehaviour
{
    // Enemy Attack Specification
    public float attackTerm;

    // Inner Active
    private EnemyAttacks ea;
    private bool isPlayerFound;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerFound = false;
        ea = this.transform.GetComponent<EnemyAttacks>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerFound = ea.GetPlayerSeeked();
    }

    IEnumerator Attack()
    {
        while(true)
        {
            if(isPlayerFound)
            {
                ea.SpawnProjectileAttack();
                yield return new WaitForSeconds(0.1f);
                ea.SpawnProjectileAttack();
                yield return new WaitForSeconds(0.1f);
                ea.SpawnProjectileAttack();
                yield return new WaitForSeconds(0.1f);

                yield return new WaitForSeconds(attackTerm);
            }

            yield return new WaitForSeconds(0);
        }
    }
}
