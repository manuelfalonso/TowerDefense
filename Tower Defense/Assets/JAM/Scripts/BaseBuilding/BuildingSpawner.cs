using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM
{
    public class BuildingSpawner : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private ObjectPool _towerPool;
        [SerializeField] private int objectDistance;
        private bool active;

        private void Awake()
        {
            active = true;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && active)
            {
                SpawnBuilding();
            }

            if (Input.GetMouseButtonDown(1)) 
            {
                active = false;
            }
        }

        private void SpawnBuilding() 
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _mainCamera.nearClipPlane + objectDistance;
            Vector3 spawnPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
            GameObject newBuilding = _towerPool.CallObjectFromPool();
            newBuilding.transform.position = spawnPosition;
        }
    }
}
