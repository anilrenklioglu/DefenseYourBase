using UnityEngine;
using DG.Tweening;
namespace Enemies
{
    public class EnemyAnimationController
    {
        private Animator _animator;
        private Tweener layerWeightTweener;
        
        public int AttackHash => Animator.StringToHash("Attack");
        public EnemyAnimationController(Animator animator)
        {
            _animator = animator;
        }
        
        public void SetLayerWeight(int layerIndex,float weight)
        {
            layerWeightTweener?.Kill();
            
            layerWeightTweener = DOTween.To(() => _animator.GetLayerWeight(layerIndex), x => _animator.SetLayerWeight(layerIndex, x), weight,
                0.5f);
        }
        
        //TODO: Trigger Attack and make shooting animation event
        
        public void TriggerAttack()
        {
            _animator.SetTrigger(AttackHash);
        }
    }
}