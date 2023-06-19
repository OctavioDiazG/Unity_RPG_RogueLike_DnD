using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentModifier : StatModifier
{
    public PercentModifier(string id, float calculate) : base(id, calculate)
    {
    }

    public override float Apply(float value)
    {
        return ((1 + calculate) * value);
    }
}
