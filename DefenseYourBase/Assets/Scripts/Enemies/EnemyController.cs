using System;
using EnumHolder;
using Structs;
using UnityEngine;
using UnityEngine.AI;
using UtilClasses;

namespace Enemies
{
    public class EnemyController:EnemyBase
    {
        public EnemySettings enemySettings;
        private EnemyBaseStateMachine _enemyCurrentState;
        private void OnEnable()
        {
            OnSwitchEnemyState += SwitchStateEnemy;
        }

        private void OnDisable()
        {
            OnSwitchEnemyState -= SwitchStateEnemy;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemySettings.movementRange);
        }
        private void Awake()
        {
            enemySettings.enemyController = this;
            enemySettings.transform = transform;
            enemySettings.agent = GetComponent<NavMeshAgent>();
            enemySettings.animationController = new EnemyAnimationController(GetComponent<Animator>());
            enemySettings.currentState = EnemyState.Movement;
            enemySettings.FieldOfView = new FieldOfView(transform);
        }
        
        private void SwitchStateEnemy(EnemyState state, EnemyController enemy)
        {
            if (enemy != this || state == enemySettings.currentState) return;
            
            _enemyCurrentState.Exit();

            switch (state)
            {
                case EnemyState.Movement:
                    _enemyCurrentState = new EnemyMovementState(enemySettings);
                    break;
                case EnemyState.Attack:
                    _enemyCurrentState = new EnemyAttackState(enemySettings);
                    break;
                case EnemyState.Die:
                    //_enemyCurrentState = new ArcherAttackState(archerSettings);
                    break;
            }
            
            enemySettings.currentState = state;
            _enemyCurrentState.Enter();
        }
        
        public override void Attack(Transform target)
        {
           
        }

        public override void Die()
        {
            
        }
        
        #region Class Specific Events

        public static event Action<EnemyState,EnemyController> OnSwitchEnemyState;

        public static void SwitchEnemyState(EnemyState state,EnemyController enemy)
        {
            OnSwitchEnemyState?.Invoke(state,enemy);
        }

        #endregion
    }
}