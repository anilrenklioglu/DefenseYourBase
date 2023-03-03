using EnumHolder;
using Structs;

namespace Player
{
    public class ArcherIdleState:ArcherBaseStateMachine
    {
        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
            CheckEnemyInCircle();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        protected override void CheckEnemyInCircle()
        {
            base.CheckEnemyInCircle();
            
            if (Archer.FieldOfView.Check360(Archer.archerAttackRadius, Archer.enemyLayers)  != null)
            {
                ArcherController.SwitchPlayerState(ArcherState.Attack,Archer.archerController);
            }
            
            else
            {
                ArcherController.SwitchPlayerState(ArcherState.Idle,Archer.archerController);
            }
        }
        public ArcherIdleState(Settings archer) : base(archer)
        {
            
        }
    }
}