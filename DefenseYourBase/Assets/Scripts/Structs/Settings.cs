using EnumHolder;
using Player;
using UnityEngine;
using UtilClasses;

namespace Structs
{
    
    [System.Serializable]
    public struct Settings 
    {
        [Header("Base Settings")]
        [Space(5)]
        
        [HideInInspector] public ArcherController archerController;
        [HideInInspector] public Transform transform;
        
        public ArcherAnimationController animationController;
        public ArcherState currentState;
        public FieldOfView FieldOfView;
        
        [Header("Archer Values")]
        [Space(5)] 
        
        public LayerMask enemyLayers;
        public float archerAttackSpeed;
        public float archerAttackRadius;
        
    }
}
