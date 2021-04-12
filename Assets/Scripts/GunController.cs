using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Gun _equippedGun;
    public Gun startingGun;

    // like socket in unreal engine
    public Transform weaponHold;


    private void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (_equippedGun != null)
        {
            Destroy(_equippedGun.gameObject);
        }
        _equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        _equippedGun.transform.SetParent(weaponHold, true);
    }

    public void Shoot()
    {
        if (_equippedGun != null)
        {
            _equippedGun.Shoot();
        }
    }
}
