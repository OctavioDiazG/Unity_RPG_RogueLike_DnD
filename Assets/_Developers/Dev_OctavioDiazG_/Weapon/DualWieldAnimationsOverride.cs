using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWieldAnimationsOverride : MonoBehaviour
{
    //array of animations
    public AnimationClip[] animations;
    
    public bool canBeDualWield;
    public bool isDualWield;

    public WeaponHolderSlot rightHandSlot;
    public WeaponHolderSlot leftHandSlot;
}
