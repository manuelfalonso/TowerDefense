using JAM.Tower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;
using JAM.Pools;

namespace JAM.Buildings
{
    public enum BuildingType 
    {
        Tower,
        Cannon,
        Other,
        None
    }

    public class BuildingSpawner : MonoBehaviourSingleton<BuildingSpawner>
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private List<BuildingPool> _towerPool;
        [SerializeField] private int objectDistance;
        [SerializeField] private ObjectPool bulletPool;
        private bool _active;
        private BuildingType _buildingType;

        protected override void Awake()
        {
            base.Awake();
            _active = false;
            _buildingType = BuildingType.Tower;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && _active)
            {
                SpawnBuilding();
            }

            if (Input.GetMouseButtonDown(1)) 
            {
                _active = false;
            }
        }

        private void SpawnBuilding() 
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _mainCamera.nearClipPlane + objectDistance;
            Vector3 spawnPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
            GameObject newBuilding = null;
            for (int i = 0; i < _towerPool.Count; i++)
            {
                if (_towerPool[i].GetBuildingType() == _buildingType)
                    newBuilding = _towerPool[i].CallObjectFromPool();
            }
            newBuilding.transform.position = spawnPosition;
            if (newBuilding.TryGetComponent<TowerBehaviour>(out TowerBehaviour newTower)) 
            {
                newTower.SetBulletPool(bulletPool);
            }
        }

        public void ActivateBuilding() 
        {
            _active = true;
        }

        public void SetBuildingType(BuildingType buildingType) 
        {
            _buildingType = buildingType;
        }
    }
}
