using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Items/Weapons")]
public class Weapons_So : ScriptableObject 
{
    
    public string weaponName;
    public float weaponCoolDownTimeAtack;
    public List<Animation> animations;

}