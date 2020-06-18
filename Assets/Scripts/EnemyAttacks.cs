using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    // Enemy Attack Specification
    public float enemyAttackRange;

    // Inner Active
    private bool playerFound;

    // Component References
    public Transform attackSpawnPoint;
    public GameObject projectilePrefab;
    public Transform attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(attackTarget);
        SeekPlayer();
    }

    public void SpawnRaycastAttack()
    {

    }

    public void SpawnProjectileAttack()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, attackSpawnPoint);
        projectileObject.transform.SetParent(null);
    }

    void SeekPlayer()
    {
        RaycastHit onRadar;

        if (Physics.Raycast(attackSpawnPoint.transform.position, attackSpawnPoint.transform.forward, out onRadar, enemyAttackRange))
        {
            if (onRadar.transform.gameObject.CompareTag("Player"))
            {
                playerFound = true;
                return;
            }
        }

        playerFound = false;
    }

    public bool GetPlayerSeeked()
    {
        return playerFound;
    }
}
