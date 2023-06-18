using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Developers.Dev_OctavioDiazG_.PlayerSystem.Scripts.structures //modify
{
    public struct Player
    {
        #region CharacterClassStats
        
        [Tooltip("indicates the total health of the player, which affects the player's life")]
        public float maxHealthPoints;
        public string maxHp;
        [Tooltip("indicates the health regeneration of the player per second")]
        public float healthRegen;
        public string hpRegen;
        [Tooltip("indicates the total stamina of the player, which affects the player's actions")]
        public float maxStaminaPoints;
        public string maxSp;
        [Tooltip("indicates the stamina regeneration of the player per second")]
        public float staminaRegen;
        public string spRegen;
        [Tooltip("indicates the total magic of the player, which affects the player's casts")]
        public float maxMagicPoints;
        public string maxMp;
        [Tooltip("indicates the magic regeneration of the player per second")]
        public float magicRegen;
        public string mpRegen;

        [Tooltip("indicates the speed of the class, which affects the player's movement speed")]
        public float speed;
        [Tooltip("indicates the Defence of the class, which affects the player's Damage Reduction")]
        public float defence;

        #endregion

        /*
        #region PlayerAttributes
        [Tooltip("indicates the strength of the player, which affects which weapons can be used (and the damage they do) (can affect in world events)")]
        public int strength; 
        [Tooltip("indicates the dexterity of the player, which affects which weapons can be used (and the speed) (can affect in world events)")]
        public int dexterity;
        [Tooltip("indicates the wisdom of the player, which affects which weapons can be used (and how many casts you can do) (can affect in world events)")]
        public int wisdom;
        [Tooltip("indicates the constitution of the player, which affects the player's Poise (how many hits you can take before being interrupted or stunned in mid action)")]
        public int constitution;
        [Tooltip("indicates the intelligence of the player, which affects the resource management of magic or stamina")]
        public int intelligence;
        [Tooltip("indicates the luck of the player, which affects the player hit damage on every attack and the chance of more rare items within the lootable probs")]
        public int luck;
        #endregion
        */

        #region other

        //public float speed;


        #endregion
    }
}