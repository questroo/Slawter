using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyAIRanges : ScriptableObject
{
    public float chaseRange = 50.0f;
    public float attackRange = 20.0f;
    public float fieldOfViewAngle = 120.0f;
}
