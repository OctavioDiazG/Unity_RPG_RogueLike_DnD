using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isLeftHandSlot;
    public bool isRightHandSlot;
    
    public GameObject currentWeaponModel;

    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        if (weaponItem == null)
        {
            UnloadWeapon();
            return;
        }
    }
    
    public void UnloadWeapon()
    {
        if (currentWeaponModel != null)
        {
            currentWeaponModel.SetActive(false);
        }
    }
}
