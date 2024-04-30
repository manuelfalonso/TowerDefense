using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JAM.Entities.Enemy;

namespace JAM.Tower
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private BaseTower towerData;
        [SerializeField] private BoxCollider collider;
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
            // Bullets pending
            if (enemiesInRange.Count != 0)
                Debug.Log("IsShooting");
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
                    Debug.Log("Add");
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
                        Debug.Log("Remove");
                        enemiesInRange.Remove(enemiesInRange[i]);
                    }
                }
            }
        }
    }
}
