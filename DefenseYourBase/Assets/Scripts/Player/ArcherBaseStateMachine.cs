using System.Diagnostics;
using StateMachines;
using Structs;
using UnityEngine;

namespace Player
{
    public class ArcherBaseStateMachine:BaseStateMachine
    {
        protected Settings Archer;
        public Transform TargetEnemy;

        public ArcherBaseStateMachine(Settings archer)
        {
            Archer = archer;
        }
        
        public override void Enter()
        {
           
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
        
        protected virtual void CheckEnemyInCircle()
        {
            
        }
    }
}