using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isRightHandSlot;
    public bool isLeftHandSlot;
    
    public GameObject currentWeaponModel;

    public void UnloadWeapon()
    {
        
        //make animation of Sheathe Weapon
        if (currentWeaponModel != null)
        {
            currentWeaponModel.SetActive(false);
        }
    }
    
    public void UnloadWeaponAndDestroy()
    {
        //make animation of Sheathe Weapon
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }
    }
    
    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        //unload current weapon and Destroy it
        UnloadWeaponAndDestroy();
        //TODO:make animation of Draw Weapon
        if (weaponItem == null)
        {
            UnloadWeapon();
            return;
        }
        GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
        if(model != null)
        {
            if (parentOverride != null)
            {
                model.transform.parent = parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }
        currentWeaponModel = model;
    }
    
}
