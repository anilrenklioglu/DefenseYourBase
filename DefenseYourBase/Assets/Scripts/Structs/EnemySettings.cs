using Enemies;
using EnumHolder;
using UnityEngine;
using UnityEngine.AI;
using UtilClasses;

namespace Structs
{
    [System.Serializable]
    public struct EnemySettings
    {
        [Header("Base Settings")]
        [Space(5)]
        
        [HideInInspector] public Transform transform;
        [HideInInspector] public EnemyController enemyController;
        
        public NavMeshAgent agent;
        public EnemyAnimationController animationController;
        public EnemyState currentState;
        public FieldOfView FieldOfView;
        
        [Header("Enemy Values")]
        [Space(5)]
        
        public float attackSpeed;
        public float attackDamage;

        [Header("Field Of View")] 
        [Space(5)] 
        
        public LayerMask enemyAttackableLayers;
        public float movementRange;
        public float attackRange;
        public float viewAngle;
       



    }
}