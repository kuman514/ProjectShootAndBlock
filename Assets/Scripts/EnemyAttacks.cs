﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    // Enemy Attack Specification
    // None Yet

    // Inner Active
    // None Yet

    // Component References
    public Transform attackSpawnPoint;
    public GameObject projectilePrefab;
    public Transform attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(attackTarget);
    }

    public void SpawnRaycastAttack()
    {

    }

    public void SpawnProjectileAttack()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, attackSpawnPoint);
        projectileObject.transform.SetParent(null);
    }
}
