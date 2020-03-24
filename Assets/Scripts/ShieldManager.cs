﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
    // Shield Specification
    public int maxMissiles;
    public int currentMissiles;
    public float chargeTimePerMissile;
    public float lengthToChangeMode;
    public float fireRate;

    // Inner Active
    private float currentChargeTimer;
    private float fireTimer;
    private bool isAttackReady;

    // Component References
    public Text MissileUI;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentChargeTimer = 0;
        fireTimer = 0;
        isAttackReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        AltFire();
        ChargeMissiles();
        ProcessTimer();
        DrawUI();
    }

    void Fire()
    {
        if(isAttackReady && Input.GetKeyDown(InputManager.Fire))
        {
            if(IsFireable())
            {
                currentMissiles--;
                fireTimer = 0;
            }
        }
    }

    void AltFire()
    {
        if(Input.GetKeyDown(InputManager.AltFire))
        {
            if(!isAttackReady)
            {
                anim.CrossFadeInFixedTime("AttackMode", lengthToChangeMode);
            }

            isAttackReady = !isAttackReady;
            anim.SetBool("IsAttackReady", isAttackReady);
        }
    }

    void ChargeMissiles()
    {
        if(!isAttackReady)
        {
            if(currentMissiles < maxMissiles)
            {
                currentChargeTimer += Time.deltaTime;
                
                if(currentChargeTimer >= chargeTimePerMissile)
                {
                    currentMissiles++;
                    currentChargeTimer = 0;
                }
            }
        }
    }

    void DrawUI()
    {
        MissileUI.text = currentMissiles + " / " + maxMissiles;
    }

    public bool GetAttackModeStatus()
    {
        return isAttackReady;
    }

    void ProcessTimer()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    bool IsFireable()
    {
        return (fireTimer >= fireRate && currentMissiles > 0);
    }
}
