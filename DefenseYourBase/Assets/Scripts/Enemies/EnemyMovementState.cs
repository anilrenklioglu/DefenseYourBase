using EnumHolder;
using Structs;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovementState:EnemyBaseStateMachine
    {
        public override void Enter()
        {
            base.Enter();
            agent.SetDestination(target.position);
            Debug.Log(target);
        }

        public override void Update()
        {
            base.Update();
            CheckAttackables();
        }

        public void CheckAttackables()
        {
            target = enemySettings.FieldOfView.Check360(enemySettings.movementRange, enemySettings.enemyAttackableLayers);
            Debug.Log(target);
            /*
            if (target != null)
            {
                EnemyController.SwitchEnemyState(EnemyState.Attack,enemySettings.enemyController);
            }*/
        }

        public EnemyMovementState(EnemySettings enemySettings) : base(enemySettings)
        {
            
        }
    }
    
}