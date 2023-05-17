using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Player : MonoBehaviour
{
    public GameObject weaponGameObject;

    [Header("Weapon Data")]
    public Weapons_So weapons_So;
    public string weaponName;
    public float weaponCoolDownTimeAtack;
    public List<Animation> weaponsAnimations;
    void Start()
    {
        weaponName = weapons_So.weaponName;
        weaponCoolDownTimeAtack = weapons_So.weaponCoolDownTimeAtack;
        for (int i = 0; i < weapons_So.animations.Count; i++)
        {
            weaponsAnimations.Add(weapons_So.animations[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Atack();
        }
    }

    void Atack()
    {

    }
}
