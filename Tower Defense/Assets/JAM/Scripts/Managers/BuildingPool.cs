using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JAM.Buildings;

namespace JAM.Pools
{
    public class BuildingPool : ObjectPool
    {
        [SerializeField] private BuildingType _buildingType;

        public BuildingType GetBuildingType()
        {
            return _buildingType;
        }
    }
}
