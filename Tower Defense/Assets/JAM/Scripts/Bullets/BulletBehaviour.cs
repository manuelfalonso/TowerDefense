using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM.Bullets
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private BaseBullet _bulletData;
        private GameObject _target;
        private float _timer = 0f;
        const string _TARGETTAG = "Enemy";

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void Movement() 
        {
            if (_target != null && _bulletData.Hooming) 
            {
                float step = _bulletData.Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
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
            Destroy(this.gameObject);
        }

        void Update()
        {
            Movement();
            BulletLifeTime();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_TARGETTAG))
            {
                BulletDestroy();
            }
        }
    }
}
