using EnumHolder;
using UnityEngine;
using StateMachines;
using Structs;
using UnityEngine.AI;


namespace Enemies
{
    public class EnemyBaseStateMachine:BaseStateMachine
    {
        protected EnemySettings enemySettings;
        protected Transform target;
        protected NavMeshAgent agent;

        public EnemyBaseStateMachine(EnemySettings enemySettings)
        {
            this.enemySettings = enemySettings;
        }
        
        public override void Enter()
        {
            agent = enemySettings.enemyController.agent;
            target = enemySettings.FieldOfView.Check360(enemySettings.movementRange, enemySettings.enemyAttackableLayers);
            
            Debug.Log(target);
        }

        public override void Update()
        {
           
        }

        public override void LateUpdate()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            
        }

        public virtual void CheckAttackables()
        {
          
        }
    }
    
}