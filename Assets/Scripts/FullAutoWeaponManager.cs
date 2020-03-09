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
    public GameObject muzzleFlashPrefab;
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
        DrawUI();
    }

    void Fire()
    {
        if (Input.GetKey(InputManager.Fire) && IsFireable())
        {
            // Animation & Sound Effect
            anim.CrossFadeInFixedTime("Fire", fireRate);
            weaponSound.PlayOneShot(fireSE);

            // Shoot point flame

            // Hit Scan
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward + Random.onUnitSphere * curScatter, out hit, shootRange))
            {
                // if hit
                Debug.Log(weaponName + " hit / Remaining ammo: " + currentAmmo + "/" + ammoPerMag);

                // Muzzle Flash on the hit object
                GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                muzzleFlash.transform.SetParent(hit.transform);
                Destroy(muzzleFlash, 1f);

                // marking bullets by using prefab
                GameObject hitHole = Instantiate(hitHolePrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                hitHole.transform.SetParent(hit.transform);
                Destroy(hitHole, 5f);

                // knockback needs hit hole not to have a Mesh Collider
                // each hit hole needs their own mesh collider removed
                Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddForceAtPosition(transform.forward * 5f * knockbackPerRound, transform.position);
                }

                // hit HP reduction does so
                // each hit hole needs their own mesh collider removed
                HealthManager hitObjHP = hit.transform.GetComponent<HealthManager>();
                if (hitObjHP != null)
                {
                    hitObjHP.Damage(damagePerRound);
                }
            }
            else
            {
                // if miss
                Debug.Log(weaponName + " miss / Remaining ammo: " + currentAmmo + "/" + ammoPerMag);
            }

            // Process
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

            // just for test
            totalAmmo += ammoPerMag;
        }
    }

    void Reload()
    {
        // Doesn't Need To (Or Can't) Reload
        if (currentAmmo >= ammoPerMag || totalAmmo <= 0)
        {
            return;
        }

        if (IsReloaded())
        {
            if (currentAmmo <= 0 || Input.GetKeyDown(InputManager.Reload))
            {
                // Animation & Sound Effect
                anim.CrossFadeInFixedTime("Reload", reloadTime);
                weaponSound.PlayOneShot(reloadSE);

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
                if (totalAmmo >= ammoPerMag)
                {
                    totalAmmo -= (ammoPerMag - currentAmmo);
                    currentAmmo = ammoPerMag;
                }
                else
                {
                    int loadAmmo = currentAmmo + totalAmmo;
                    int remainAmmo = loadAmmo - ammoPerMag;

                    if(remainAmmo > 0)
                    {
                        currentAmmo = ammoPerMag;
                        totalAmmo = remainAmmo;
                    }
                    else
                    {
                        currentAmmo = loadAmmo;
                        totalAmmo = 0;
                    }
                }
            }
        }
    }

    void DrawUI()
    {
        ammoUI.text = currentAmmo + " / " + totalAmmo;
    }

    bool IsFireable()
    {
        return (currentAmmo > 0 && fireTimer >= fireRate && reloading >= reloadTime);
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
