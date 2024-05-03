using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM.Bullets
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private BaseBullet _bulletData;
        private Vector3 _target;
        private float _timer = 0f;

        public void SetTarget(Vector3 target)
        {
            _target = target;
        }

        private void Movement() 
        {
            if (_target != null && _bulletData.DirectTowardsPlayer) 
            {
                float step = _bulletData.Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target, step);
            }
            else 
            {
                transform.position += _bulletData.Direction * _bulletData.Speed * Time.deltaTime;
            }
        }

        private void BulletLifeTime() 
        {
            _timer += Time.deltaTime;
            if (_timer >= _bulletData.LifeTime) 
            {
                BulletDestroy();
            }
        }

        public void BulletDestroy() 
        {
            _timer = 0f;
            this.gameObject.SetActive(false);
        }

        void Update()
        {
            Movement();
            BulletLifeTime();
        }
    }
}
