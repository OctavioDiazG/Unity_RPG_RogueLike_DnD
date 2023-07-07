using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatModifier
{
    public string id { get; }
    protected float calculate;

    protected StatModifier(string id, float calculate)
    {
        this.id = id;
        this.calculate = calculate;
    }

    public abstract float Apply(float value);
}
