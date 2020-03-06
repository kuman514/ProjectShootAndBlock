using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Key Settings
    public static KeyCode Forward;
    public static KeyCode Backward;
    public static KeyCode Left;
    public static KeyCode Right;

    public static KeyCode Jump;
    public static KeyCode Duck;
    public static KeyCode Sprint;

    public static KeyCode Interact;
    public static KeyCode Reload;

    public static KeyCode Fire;
    public static KeyCode AltFire;

    public static KeyCode PrimaryWeapon;
    public static KeyCode SecondaryWeapon;
    public static KeyCode PriSecSwitch;
    //public static KeyCode UltimateWeapon;

    // references
    public InputSettings sets;

    // Start is called before the first frame update
    void Start()
    {
        Forward = sets.Forward;
        Backward = sets.Backward;
        Left = sets.Left;
        Right = sets.Right;

        Jump = sets.Jump;
        Duck = sets.Duck;
        Sprint = sets.Sprint;

        Interact = sets.Interact;
        Reload = sets.Reload;

        Fire = sets.Fire;
        AltFire = sets.AltFire;

        PrimaryWeapon = sets.PrimaryWeapon;
        SecondaryWeapon = sets.SecondaryWeapon;
        PriSecSwitch = sets.PriSecSwitch;
        //UltimateWeapon = sets.UltimateWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
