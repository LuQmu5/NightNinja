using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [field: SerializeField, Min(1)] public float Speed { get; private set; }
}
