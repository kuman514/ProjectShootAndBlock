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

    // Inner Active
    //private float currentChargeTimer;

    // Component References
    public Text MissileUI;

    // Start is called before the first frame update
    void Start()
    {
        //currentChargeTimer = chargeTimePerMissile;
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

    }

    void AltFire()
    {

    }

    void ChargeMissiles()
    {

    }

    void DrawUI()
    {
        MissileUI.text = "Force Shield";
    }
}
