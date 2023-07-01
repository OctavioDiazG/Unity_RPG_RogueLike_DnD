using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    private Hashtable stats;

    public void Initialize(List<StatData> _stats)
    {
        stats = new Hashtable();

        foreach (StatData data in _stats)
        {
            stats.Add(data.id, new StatDefinition(data.value));
        }
    }

    public StatDefinition Find(string id)
    {
        if (stats.ContainsKey(id))
        {
            // Retrieve the StatDefinition associated with the ID
            return (StatDefinition)stats[id];
        }

        // ID not found
        return null;
    }

    public void Update()
    {
        foreach(StatDefinition stat in stats.Values)
        {
            if (stat.isDirty)
            {
                stat.Calculate();
            }
        }
    }
}
