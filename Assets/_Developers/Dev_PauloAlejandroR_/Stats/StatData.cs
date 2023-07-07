using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StatData
{
    public string id;
    public float value;

    public StatData(string id, float value)
    {
        this.id = id;
        this.value = value;
    }
}