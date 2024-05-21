using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

namespace JAM.Buildings
{
    public class BuildingSelector : MonoBehaviourSingleton<BuildingSelector>
    {
        private void Update()
        {
            SelectBuilding();
        }

        private void SelectBuilding() 
        {
            if (Input.GetKeyDown("1"))
            {
                BuildingSpawner.Instance.SetBuildingType(BuildingType.Tower);
                BuildingSpawner.Instance.ActivateBuilding();
            }
            if (Input.GetKeyDown("2"))
            {
                BuildingSpawner.Instance.SetBuildingType(BuildingType.Cannon);
                BuildingSpawner.Instance.ActivateBuilding();
            }
            if (Input.GetKeyDown("3"))
            {
                BuildingSpawner.Instance.SetBuildingType(BuildingType.Other);
                BuildingSpawner.Instance.ActivateBuilding();
            }
        }
    }
}
