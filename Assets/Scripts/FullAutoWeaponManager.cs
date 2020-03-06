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
        
    }

    void Fire()
    {

    }

    void AltFire()
    {

    }

    void Reload()
    {

    }

    void ProcessTimers()
    {

    }
}
