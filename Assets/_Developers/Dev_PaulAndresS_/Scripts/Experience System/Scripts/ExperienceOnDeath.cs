using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOnDeath : MonoBehaviour
{
    [SerializeField] private int m_ExperienceAmount;
    

    private void OnDamageHandler(GameObject damager, int amount)
    {
        // Si ya ha muerto
        //if(health.Health <= 0)
        //{
            // Aplica la experiencia a quien haya aplicado el daño
            IExperience experience = damager.GetComponent<IExperience>();
            experience?.AddExperience(m_ExperienceAmount);
        //}
    }
}
