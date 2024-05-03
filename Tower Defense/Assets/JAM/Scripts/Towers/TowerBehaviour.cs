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
        [SerializeField] private BoxCollider collider;
        [SerializeField] private GameObject bulletToShoot;
        private float secondsToShoot;
        private List<Enemy> enemiesInRange;

        private void Awake()
        {
            collider.size = towerData.Range;
            secondsToShoot = 0;
            enemiesInRange = new List<Enemy>();
        }

        private void Shoot() 
        {
            if (enemiesInRange.Count != 0)
            {
                GameObject newBullet = Instantiate(bulletToShoot, transform.position, transform.rotation);
                if (newBullet.TryGetComponent<BulletBehaviour>(out BulletBehaviour bulletBehaviour)) 
                {
                    bulletBehaviour.SetTarget(enemiesInRange[0].gameObject.transform.position);
                }
            }
        }

        private void OnTargetBehaviour() 
        {
            secondsToShoot += Time.deltaTime;
            if (secondsToShoot >= towerData.SecondsToShoot) 
            {
                Shoot();
                secondsToShoot = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy newEnemy;
            if (other.gameObject.tag == "Enemy") 
            {
                if (other.gameObject.TryGetComponent<Enemy>(out newEnemy)) 
                {
                    enemiesInRange.Add(newEnemy);
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Enemy") 
            {
                OnTargetBehaviour();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                for (int i = 0; i < enemiesInRange.Count; i++)
                {
                    if (enemiesInRange[i].gameObject == other.gameObject)
                    {
                        enemiesInRange.Remove(enemiesInRange[i]);
                    }
                }
            }
        }
    }
}
