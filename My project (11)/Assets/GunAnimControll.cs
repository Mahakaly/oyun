using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunAnimControll : MonoBehaviour
{
    [SerializeField] public static GunAnimControll instance;
    private Animator animator;

    
    // Enum to represent different weapon types
    public enum WeaponType
    {
        Pistol,
        Rifle,
        
        // Add more weapon types as needed
    }

    // Current weapon type
    public WeaponType currentWeapon = WeaponType.Pistol;



    public GameObject pistolPrefab;
    public GameObject riflePrefab;

    private GameObject currentWeaponPrefab;

    void Start()
    {
        instance = this;
        // Get the Animator component from the player
        animator = GetComponent<Animator>();
        ChangeWeapon(currentWeapon);
    }
    public WeaponType CurrentWeapon
    {
        get { return currentWeapon; }
    }

    void Update()
    {
        // Check for input to change weapon (you can replace this with your own logic)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(WeaponType.Pistol);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(WeaponType.Rifle);
        }
        
        // Add more input checks for additional weapons
    }

  public  void ChangeWeapon(WeaponType newWeapon)
    {
        if(currentWeaponPrefab!= null)
        {
            currentWeaponPrefab.SetActive(false);
        }

        switch (newWeapon)
        {
            case WeaponType.Pistol:
                currentWeaponPrefab = pistolPrefab;
                break;
                case WeaponType.Rifle:
                currentWeaponPrefab = riflePrefab;
                break;
        }
        if(currentWeaponPrefab != null)
        {
            currentWeaponPrefab.SetActive(true);
        }

        // Set the "WeaponType" parameter in the Animator Controller
        animator.SetInteger("WeaponType", (int)newWeapon);

        // Update the current weapon type
        currentWeapon = newWeapon;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {
            ChangeWeapon(currentWeapon);
        }
    }

}