using System;
using EnumHolder;
using Structs;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public NavMeshAgent agent;
        
        public abstract void Attack (Transform target);
        public abstract void Die();
        
        public virtual void Move(Transform target)
        {
            agent.SetDestination(target.position);
        }
        
    }
}
