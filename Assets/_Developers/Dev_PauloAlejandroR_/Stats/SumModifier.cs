using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumModifier : StatModifier
{
    public SumModifier(string id, float calculate) : base(id, calculate)
    {

    }

    public override float Apply(float value)
    {
        return (calculate + value);
    }
}
