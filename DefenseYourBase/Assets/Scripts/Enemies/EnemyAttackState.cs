using EnumHolder;
using Structs;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttackState:EnemyBaseStateMachine
    {
        private int animationLayerIndex = 1;
        public override void Enter()
        {
            base.Enter();
            enemySettings.animationController.SetLayerWeight(animationLayerIndex,1);
        }

        public override void Update()
        {
            base.Update();
        }
        
        public EnemyAttackState(EnemySettings enemySettings) : base(enemySettings)
        {
            
        }
    }
}