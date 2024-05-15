using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM
{
    public class BuildingSpawner : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private ObjectPool _towerPool;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBuilding();
            }
        }

        private void SpawnBuilding() 
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 spawnPosition = _mainCamera.ScreenToViewportPoint(mousePosition);
            GameObject newBuilding = _towerPool.CallObjectFromPool();
            newBuilding.transform.position = spawnPosition;
        }
    }
}
