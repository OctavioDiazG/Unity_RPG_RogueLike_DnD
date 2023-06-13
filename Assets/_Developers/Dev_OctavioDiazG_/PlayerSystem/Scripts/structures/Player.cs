using System.Collections.Generic;
using UnityEngine;

namespace _Developers.Dev_OctavioDiazG_.PlayerSystem.Scripts.structures //modify
{
    public struct Player
    {
        #region PlayerStats
        [Tooltip("indicates the health of the player, which affects the player's life")]
        public float healthPoints;
        [Tooltip("indicates the stamina of the player, which affects the player's actions")]
        public float staminaPoints;
        [Tooltip("indicates the magic of the player, which affects the player's casts")]
        public float magicPoints;
        [Tooltip("indicates the experience of the player, which affects the player's level")]
        public float experiencePoints;
        #endregion
        
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

        #region other

        public float speed;
        

        #endregion
    }
}