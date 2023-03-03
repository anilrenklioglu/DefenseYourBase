using Enemies;
using UnityEngine;

namespace Structs
{
    public struct EnemySettings
    {
        [Header("Base Settings")]
        [Space(5)]
        
        [HideInInspector] public Transform transform;
        [HideInInspector] public EnemyBase enemyBase;
        
        
    }
}