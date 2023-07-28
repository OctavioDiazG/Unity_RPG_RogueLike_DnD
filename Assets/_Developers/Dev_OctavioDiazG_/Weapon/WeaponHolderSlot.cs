using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isRightHandSlot;
    public bool isLeftHandSlot;
    public WeaponItem FistWeaponItem;


    public GameObject currentWeaponModel;
    
    public DualWieldAnimationsOverride dualWieldAnimationsOverride;

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
            LoadWeaponModel(FistWeaponItem);
        }
    }
    
    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        List<KeyValuePair<AnimationClip, AnimationClip>> overrideAnim = new();
        if (dualWieldAnimationsOverride.isDualWield)  //this is not going to work because the variables are not set to true at the same time but in one script and in the other script
        {
            //!!!!Currently Not Working!!!!
            //Create a new overrideAnim List for all the dual wield animations
            #region Basic Locomotion
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Idle"],dualWieldAnimationsOverride.animations[0]));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Walk"],dualWieldAnimationsOverride.animations[1]));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Run"],dualWieldAnimationsOverride.animations[2]));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Sprint"],dualWieldAnimationsOverride.animations[3]));
            #endregion
            #region Rolls
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["RollForward"],dualWieldAnimationsOverride.animations[4]));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["RollBackward"],dualWieldAnimationsOverride.animations[5]));
            #endregion
            #region Draw and Sheathe Weapon
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Draw"],dualWieldAnimationsOverride.animations[6]));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Sheathe"],dualWieldAnimationsOverride.animations[7]));
            #endregion
            
            Debug.Log("DualWield Animations Override");
            
            weaponItem.animatorOverride.ApplyOverrides(overrideAnim);
        }
        else //any other weapons that are not Dual Wield
        {
            //!!!!Currently Not Working!!!!
            #region Basic Locomotion
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Idle"],weaponItem.Idle));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Walk"],weaponItem.Walk));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Run"],weaponItem.Run));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Sprint"],weaponItem.Sprint));
            #endregion
            #region Rolls
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["RollForward"],weaponItem.RollForward));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["RollBackward"],weaponItem.RollBackward));
            #endregion
            #region Draw and Sheathe Weapon
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Draw"],weaponItem.Draw));
            overrideAnim.Add(new KeyValuePair<AnimationClip,AnimationClip>(weaponItem.animatorOverride["Sheathe"],weaponItem.Sheathe));
            #endregion
            
            Debug.Log("No DualWield Animations Override");
            
            weaponItem.animatorOverride.ApplyOverrides(overrideAnim);
        }
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
