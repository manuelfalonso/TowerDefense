using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JAM.Entities.Enemy;
using JAM.Bullets;

namespace JAM.Tower
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private BaseTower towerData;
        [SerializeField] private SphereCollider collider;
        [SerializeField] private BulletBehaviour bulletToShoot;
        private float secondsToShoot;
        private const string _ENEMYTAG = "Enemy";
        private List<Enemy> enemiesInRange;

        private void Awake()
        {
            collider.radius = towerData.Range;
            secondsToShoot = 0;
            enemiesInRange = new List<Enemy>();
        }

        private void Shoot() 
        {
            if (enemiesInRange.Count != 0)
            {
                BulletBehaviour newBullet = Instantiate<BulletBehaviour>(bulletToShoot, transform.position, transform.rotation);
                newBullet.SetTarget(enemiesInRange[0].gameObject);
            }
        }

        private void OnTargetBehaviour() 
        {
            if (enemiesInRange.Count > 0)
            {
                secondsToShoot += Time.deltaTime;
                if (secondsToShoot >= towerData.SecondsToShoot)
                {
                    Shoot();
                    secondsToShoot = 0;
                }
            }
        }

        private void Update()
        {
            OnTargetBehaviour();
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy newEnemy;
            if (other.CompareTag(_ENEMYTAG)) 
            {
                if (other.gameObject.TryGetComponent<Enemy>(out newEnemy)) 
                {
                    enemiesInRange.Add(newEnemy);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_ENEMYTAG))
            {
                if (other.TryGetComponent(out Enemy enemy)) 
                {
                    enemiesInRange.Remove(enemy);
                }
            }
        }
    }
}
