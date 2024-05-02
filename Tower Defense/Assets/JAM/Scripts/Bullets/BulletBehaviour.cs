using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM.Bullets
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private BaseBullet _bulletData;
        [SerializeField] private Vector3 _target;

        public void SetTarget(Vector3 target)
        {
            _target = target;
        }

        private void Movement() 
        {
            if (_target != null && _bulletData.DirectTowardsPlayer) 
            {
                
            }
            else 
            {
                
            }
        }

        void Update()
        {
            Movement();
        }
    }
}
