using JAM.Shared.Systems.Resource;
using UnityEngine;
using Utils.Singleton;

namespace JAM.Resources
{
    /// <summary>
    /// Game Resources Singleton to manage all the resources in the game
    /// </summary>
    public class GameResources : MonoBehaviourSingleton<GameResources>
    {
        [Header("Game Resources")]
        [SerializeField] private HealthResourceSystem PataconesResource;
        [SerializeField] private HealthResourceSystem MetalResource;
        [SerializeField] private HealthResourceSystem UraniumResource;
        [SerializeField] private HealthResourceSystem ElectricityResource;
    }
}
