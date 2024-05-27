using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

namespace JAM.Buildings
{
    public class BuildingSelector : MonoBehaviourSingleton<BuildingSelector>
    {
        [SerializeField] private string tower;
        [SerializeField] private string cannon;
        [SerializeField] private string other;

        private void Update()
        {
            SelectBuilding();
        }

        private void SelectBuilding() 
        {
            if (Input.GetKeyDown(tower))
            {
                BuildingSpawner.Instance.SetBuildingType(BuildingType.Tower);
                BuildingSpawner.Instance.ActivateBuilding();
            }
            if (Input.GetKeyDown(cannon))
            {
                BuildingSpawner.Instance.SetBuildingType(BuildingType.Cannon);
                BuildingSpawner.Instance.ActivateBuilding();
            }
            if (Input.GetKeyDown(other))
            {
                BuildingSpawner.Instance.SetBuildingType(BuildingType.Other);
                BuildingSpawner.Instance.ActivateBuilding();
            }
        }
    }
}
