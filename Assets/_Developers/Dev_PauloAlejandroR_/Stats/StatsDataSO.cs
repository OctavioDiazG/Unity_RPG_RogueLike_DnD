using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable object/Stats")]
public class StatsDataSO : ScriptableObject
{
    [SerializeField]
    private List<StatData> stats;
    public List<StatData> Stats => stats;
}
