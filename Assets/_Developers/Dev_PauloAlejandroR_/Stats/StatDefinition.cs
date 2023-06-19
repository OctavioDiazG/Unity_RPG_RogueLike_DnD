using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatDefinition
{
    private float baseValue;
    private List<StatModifier> modifiers = new List<StatModifier>();

    public bool isDirty { get; private set; }

    public StatDefinition(float baseValue)
    {
        this.baseValue = baseValue;
        realValue= baseValue;
    }

    public float realValue { get; private set; }

    public void AddModifier(StatModifier modifier)
    {
        modifiers.Add(modifier);
        isDirty = true;
    }

    public bool RemoveModifier(string id)
    {
        foreach (StatModifier modifier in modifiers)
        {
            if (modifier.id == id)
            {
                modifiers.Remove(modifier);
                isDirty = true;
                return true;
            }
        }

        return false;
    }

    public void Calculate()
    {
        if (isDirty)
        {
            realValue = baseValue;
            foreach (StatModifier modifier in modifiers)
            {
                realValue = modifier.Apply(realValue);
            }
            isDirty = false;
        }
    }
}
