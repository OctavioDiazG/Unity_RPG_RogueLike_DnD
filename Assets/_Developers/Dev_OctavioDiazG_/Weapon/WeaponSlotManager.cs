using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;
    public DualWieldAnimationsOverride dualWield;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>(); //Get all the weapon holder slots in the children of this game object
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {

            /*if (weaponSlot.isRightHandSlot) //this way the player must have a right hand slot in order to have a left hand slot
            {
                rightHandSlot = weaponSlot;
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
            }*/
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }
    
    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (!isLeft)
        {
            dualWield.isDualWield = true; //Test Purposes
            rightHandSlot.LoadWeaponModel(weaponItem);
            dualWield.canBeDualWield = true;
        }
        if (isLeft && dualWield.canBeDualWield)
        {
            dualWield.isDualWield = true;
            Debug.Log("DualWield.isDualWield = true");
            leftHandSlot.LoadWeaponModel(weaponItem);
        }

        //FIXME: This is not working properly, the player cant have a weapon in the left hand without having one in the right hand
        /*if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
        }*/
    }
}
