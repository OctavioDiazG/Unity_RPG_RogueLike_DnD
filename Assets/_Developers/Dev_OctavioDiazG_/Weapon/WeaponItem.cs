using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject modelPrefab;
    public bool isOneHanded;
    //public bool isTwoHanded;
    public AnimatorOverrideController animatorOverride;
    
    [Header("Roll Animations")]
    [Header("Locomotion Animations")]
    public AnimationClip Idle;
    public AnimationClip Walk;
    public AnimationClip Run;
    public AnimationClip Sprint;
    
    [Header("Roll Animations")]
    public AnimationClip RollForward;
    public AnimationClip RollBackward;
    
    [Header("Draw and Sheathe Weapon Animations")]
    public AnimationClip Draw;
    public AnimationClip Sheathe;

    [Header("One Handed Light Attack Animations")]
    public AnimationClip Light_Attack_1;
    public string OH_Light_Attack_1;
    public string OH_Light_Attack_2;
    public string OH_Light_Attack_3;
    [Header("One Handed Heavy Attack Animations")]
    public string OH_Heavy_Attack_1;
    public string OH_Heavy_Attack_2;
    public string OH_Heavy_Attack_3;
    
    
    
}
