using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private BaseTower towerData;

        public bool IsInFOV(Vector3 targetPosition) 
        {
            float distance = Vector3.Distance(targetPosition, transform.position);

            if (distance > towerData.Range)
                return false;
            return true;
        }

        public void Shoot() 
        {
            // Bullets pending
        }
    }
}
