using EnumHolder;
using Structs;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class ArcherAttackState:ArcherBaseStateMachine
    {
        private int animationLayerIndex = 1;
        
        
        public ArcherAttackState(Settings archer) : base(archer)
        {
            this.Archer = archer;    
        }
        
        public override void Enter()
        {
            base.Enter();
           Archer.animationController.SetLayerWeight(animationLayerIndex,1);
        }

        public override void Update()
        {
            base.Update();
            CheckEnemiesInCircle();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
          
        }
        
        public override void Exit()
        {
            base.Exit();
            
            Archer.animationController.SetLayerWeight(animationLayerIndex,0);
        }
        
        private void CheckEnemiesInCircle()
        {
            TargetEnemy = Archer.FieldOfView.Check360(Archer.archerAttackRadius, Archer.enemyLayers);
            
            Debug.Log("ATTACK STATE'S TARGET: " + TargetEnemy);
            
            if (TargetEnemy == null)
            {
                ArcherController.SwitchPlayerState(ArcherState.Idle, Archer.archerController);
                Debug.Log("The archer is NOT attacking to capsule");
            }
        }
    }
}