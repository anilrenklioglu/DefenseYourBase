using UnityEngine;
using StateMachines;


namespace Enemies
{
    public class EnemyBaseStateMachine:BaseStateMachine
    {
        protected EnemyBase enemyBase;
        protected Transform target;

        public EnemyBaseStateMachine(EnemyBase enemyBase, Transform target)
        {
            this.enemyBase = enemyBase;
            this.target = target;
        }

        public override void Enter()
        {
            enemyBase.agent.SetDestination(target.position);
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
    }
    
}