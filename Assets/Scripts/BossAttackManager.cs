using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    // Enemy Attack Specification
    public float attackTerm;

    // Inner Active
    private EnemyAttacks ea;
    bool seenPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ea = this.transform.GetComponent<EnemyAttacks>();
        seenPlayer = false;
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
            Seek();

            if(seenPlayer)
            {
                ea.SpawnProjectileAttack();
                yield return new WaitForSeconds(attackTerm);
            }
        }
    }

    void Seek()
    {
        if(ea != null)
        {
            //seenPlayer = ea.SeekPlayer();
        }
    }
}
