using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : MonoBehaviour
{
    public StatsDataSO stats;
    private StatsController statsController;
    private void Awake()
    {
        statsController = FindObjectOfType<StatsController>();
    }
    void Start()
    {
        statsController.Initialize(stats.Stats);
    }

    private void Update()
    {
        Debug.Log(statsController.Find("Health").realValue);
        Debug.Log(statsController.Find("Stamina").realValue);
    }
}
