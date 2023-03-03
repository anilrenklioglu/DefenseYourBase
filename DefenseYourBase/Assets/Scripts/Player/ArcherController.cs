
using System;
using EnumHolder;
using Structs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UtilClasses;

namespace Player
{
    public class ArcherController : MonoBehaviour
    {
         public Settings archerSettings;

        private ArcherBaseStateMachine _archerCurrentState;

        private void OnEnable()
        {
            OnSwitchPlayerState += SwitchState;
        }

        private void OnDisable()
        {
            OnSwitchPlayerState -= SwitchState;
        }

        private void Awake()
        {
          archerSettings.archerController = this;
          archerSettings.transform = transform;
          archerSettings.animationController = new ArcherAnimationController(GetComponent<Animator>());
          archerSettings.currentState = ArcherState.Idle;
          archerSettings.FieldOfView = new FieldOfView(transform);
          _archerCurrentState = new ArcherIdleState(archerSettings);
        }

        private void Update()
        {
            _archerCurrentState.Update();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, archerSettings.archerAttackRadius);
        }
        
        private void SwitchState(ArcherState state, ArcherController playerArcher)
        {
            if (playerArcher != this || state == archerSettings.currentState) return;
            
            _archerCurrentState.Exit();

            switch (state)
            {
                case ArcherState.Idle:
                    _archerCurrentState = new ArcherIdleState(archerSettings);
                    
                    break;
                case ArcherState.Attack:
                    _archerCurrentState = new ArcherAttackState(archerSettings);
                    break;
            }
            
            archerSettings.currentState = state;
            _archerCurrentState.Enter();
        }
        
        
        #region Class Specific Events

        public static event Action<ArcherState,ArcherController> OnSwitchPlayerState;

        public static void SwitchPlayerState(ArcherState state,ArcherController archer)
        {
            OnSwitchPlayerState?.Invoke(state,archer);
        }

        #endregion
    }
}
