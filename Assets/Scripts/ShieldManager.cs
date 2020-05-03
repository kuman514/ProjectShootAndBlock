using System.Collections;
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
    public float missileTargetRange;

    // Inner Active
    private float currentChargeTimer;
    private float fireTimer;
    private bool isAttackReady;
    private AudioSource shieldAudio;

    // Component References
    public Text MissileUI;
    public Animator anim;
    public GameObject missilePrefab;
    public Transform missilePoint;
    public AudioClip missileFireSE;
    public AudioClip shieldBlockSE;
    public BoxCollider shieldBody;

    // Start is called before the first frame update
    void Start()
    {
        currentChargeTimer = 0;
        fireTimer = 0;
        isAttackReady = false;
        shieldAudio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveStatus();
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
                RaycastHit hit;
                Transform targetPos;
                Physics.Raycast(missilePoint.position, missilePoint.transform.forward, out hit, missileTargetRange);
                targetPos = hit.transform;

                GameObject missile = Instantiate(missilePrefab, missilePoint);
                ShieldMissile sm = missile.transform.GetComponent<ShieldMissile>();
                if(targetPos != null && hit.transform.gameObject.CompareTag("Enemy"))
                {
                    sm.target = targetPos;
                }
                missile.transform.SetParent(null);

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

            if (isAttackReady)
            {
                shieldBody.enabled = false;
            }
            else
            {
                shieldBody.enabled = true;
            }
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

    void PlayShieldBlockSE()
    {
        if (shieldAudio != null && shieldBlockSE != null)
        {
            shieldAudio.PlayOneShot(shieldBlockSE);
        }
    }

    void ActiveStatus()
    {
        if(!this.transform.gameObject.activeSelf)
        {
            isAttackReady = false;
        }
    }
}
