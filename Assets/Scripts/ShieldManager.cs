using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
    // Shield Specification
    //public int maxMissiles;
    //public int currentMissiles;
    //public float chargeTimePerMissile;
    public float lengthToChangeMode;

    // Inner Active
    //private float currentChargeTimer;
    private bool isAttackReady;

    // Component References
    public Text MissileUI;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //currentChargeTimer = chargeTimePerMissile;
        isAttackReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        AltFire();
        ChargeMissiles();
        DrawUI();
    }

    void Fire()
    {
        if(isAttackReady && Input.GetKeyDown(InputManager.Fire))
        {

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

        }
    }

    void DrawUI()
    {
        if(isAttackReady)
        {
            MissileUI.text = "Missile Attack Mode";
        }
        else
        {
            MissileUI.text = "Force Shield";
        }
    }

    public bool GetAttackModeStatus()
    {
        return isAttackReady;
    }
}
