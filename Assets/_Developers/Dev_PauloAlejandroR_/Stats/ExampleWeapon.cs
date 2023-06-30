using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleWeapon : MonoBehaviour
{
    private StatsController StatsController;

    private void Start()
    {
        StatsController = FindObjectOfType<StatsController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PercentModifier percentModifier = new PercentModifier("weaponHealth", -0.1f);
            SumModifier sumModifier = new SumModifier("weaponStamina", 20f);
            StatDefinition healthStat = StatsController.Find("Health");
            StatDefinition staminaStat = StatsController.Find("Stamina");
            healthStat.AddModifier(percentModifier);
            staminaStat.AddModifier(sumModifier);
        }
    }
}
