using UnityEngine;

namespace _Developers.Dev_OctavioDiazG_.PlayerSystem.Scripts.scriptableObject //modify
{
    [CreateAssetMenu(fileName = "ClassData", menuName = "Player/ PlayerCharacterClass", order = 0)]
    public class PlayerCharacterClassSO : ScriptableObject
    {
        //here will lie all the data related to the class of the player, this way i can create all the classes i want so the player can choose which one to play with

        [Header("Class Definition")] 
        public string className;
        public string classDescription;
        public Sprite classIcon;
        public GameObject classModel;
        
        [Header("Class Initial Weapon")]
        public GameObject weapon;

        [Header("Class Initial Stats")]
        public float classHealthPoints;
        public float classStaminaPoints;
        public float classMagicPoints;
        
        [Header("Class Initial Properties")]
        [Tooltip("indicates the speed of the class, which affects the player's movement speed")]
        public float classSpeed;
        [Tooltip("indicates the Defence of the class, which affects the player's Damage Reduction")]
        public float classDefence;
        [Tooltip("indicates the Melee Damage of the class, which affects the player's Melee Damage")]
        public float classMeleeDamage;
        [Tooltip("indicates the Magic Damage of the class, which affects the player's Magic Damage")]
        public float classMagicDamage;
        

    }
}