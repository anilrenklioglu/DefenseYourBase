using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UtilClasses
{
    public class FieldOfView
    {
        protected Transform Transform;
        protected List<Transform> VisibleTargets = new List<Transform>();

        public Transform ClosestEnemy {get; set;}
        public Transform TargetEnemy {get; set;}
        public bool IsEnemyInSight {get; set;}
        public FieldOfView(Transform transform)
        {
            Transform = transform;
        }
        
        public Transform Check360(float radius, LayerMask layerMask)
        {
            VisibleTargets.Clear();
            CheckVisibleListIn360Fov(radius);

            Collider[] colliders = Physics.OverlapSphere(Transform.position, radius, layerMask);

            if (colliders.Length < 1)
            {
                IsEnemyInSight = false;
                return null;
            }

            for (int i = 0; i < colliders.Length; i++)
            {
                VisibleTargets.Add(colliders[i].transform);
                IsEnemyInSight = true;
            }

            ClosestEnemy = GetClosestPoint();

            Debug.Log("Current enemy is: " + ClosestEnemy.name);

            return ClosestEnemy;
        }
        
        private Transform GetClosestPoint()
        {
            float closestDistance = Mathf.Infinity;
            Transform closestPoint = null;
            for (int i = 0; i < VisibleTargets.Count; i++)
            {
                if(VisibleTargets[i] == null) continue;
                
                float distance = Vector3.Distance(Transform.position, VisibleTargets[i].position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = VisibleTargets[i];
                }
            }
            return closestPoint;
        }
        
        private void CheckVisibleListIn360Fov(float radius)
        {
            int i = 0;
            while (i < VisibleTargets.Count)
            {
                if (VisibleTargets[i] == null)
                {
                    VisibleTargets.RemoveAt(i);
                    continue;
                }
                
                float distance = Vector3.Distance(Transform.position, VisibleTargets[i].position);

                if (distance > radius)
                {
                    VisibleTargets.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}