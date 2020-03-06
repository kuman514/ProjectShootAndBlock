using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullAutoWeaponManager : MonoBehaviour
{
    // Weapon Specification
    public string weaponName;

    public int ammoPerMag;
    public int currentAmmo;
    public int totalAmmo;

    public float shootRange;
    public float fireRate;
    public float altFireRate;
    public float reloadTime;

    public float maxScatter;
    public float scatterIncreasePerRound;
    public float scatterReduction;

    public float damagePerRound;
    public float knockbackPerRound;

    // Inner Active
    private float fireTimer;
    private float altFireTimer;
    private float reloading;
    private float curScatter;

    // Component References
    public Transform shootPoint;

    public Animator anim;
    public Text ammoUI;

    public AudioSource weaponSound;
    public AudioClip fireSE;
    public AudioClip reloadSE;

    public GameObject hitHolePrefab;
    //public Vector3 recoilKickback;
    //public Transform casingExit;
    //public GameObject bulletCasing;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireRate;
        altFireTimer = altFireRate;
        reloading = reloadTime;
        curScatter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        AltFire();
        Reload();
        ProcessTimers();
    }

    void Fire()
    {
        if (Input.GetKey(InputManager.Fire) && IsFireable())
        {
            // Animation & Sound Effect
            anim.CrossFadeInFixedTime("Fire", fireRate);

            // Muzzle Flash

            // Hit Scan

            // Process
            Debug.Log(weaponName + ": Fire");
            fireTimer = 0;
            currentAmmo--;
        }
    }

    void AltFire()
    {
        if (Input.GetKey(InputManager.AltFire) && IsAltFireable())
        {
            // Alt Fire Object

            // Process
            Debug.Log(weaponName + ": Alt Fire");
            altFireTimer = 0;
        }
    }

    void Reload()
    {
        // Doesn't Need To Reload
        if (currentAmmo >= ammoPerMag)
        {
            return;
        }

        if (IsReloaded())
        {
            if (currentAmmo <= 0 || Input.GetKeyDown(InputManager.Reload))
            {
                // Animation & Sound Effect
                anim.CrossFadeInFixedTime("Reload", reloadTime);

                // Process
                reloading = 0;
            }
        }
    }

    void ProcessTimers()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        if (altFireTimer < altFireRate)
        {
            altFireTimer += Time.deltaTime;
        }

        if (reloading < reloadTime)
        {
            reloading += Time.deltaTime;

            if (IsReloaded())
            {
                totalAmmo -= (ammoPerMag - currentAmmo);
                currentAmmo = ammoPerMag;
            }
        }
    }

    bool IsFireable()
    {
        return (currentAmmo > 0 && fireTimer >= fireRate);
    }

    bool IsAltFireable()
    {
        return (altFireTimer >= altFireRate);
    }

    bool IsReloaded()
    {
        return (reloading >= reloadTime);
    }
}
