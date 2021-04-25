using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour

{
    private WeaponManager weapon_Manager;

    public float nextTimeToFire;
    public float damage = 20f;

    private Camera mainCam;

    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
        mainCam = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        if(weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.SINGLE){
            if(Input.GetMouseButtonDown(0))
            {
                if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired();
                }
            }
        }
    }
    void BulletFired()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit ))
        {
            print("WE HIT: " + hit.transform.gameObject.name);
            if(hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    }
}































