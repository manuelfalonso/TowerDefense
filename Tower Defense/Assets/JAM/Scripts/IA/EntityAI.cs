using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace JAM.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EntityAI : MonoBehaviour
    {
        [SerializeReference] private NavMeshAgent _navMeshAgent;

        [BoxGroup("Destination")]
        [SerializeField] private Transform _transformDestination;
        [BoxGroup("Destination")]
        [SerializeField] private Vector3 _vector3Destination;


        private void Awake()
        {
            TryGetComponent(out _navMeshAgent);
        }

        [Button(enabledMode: EButtonEnableMode.Playmode)]
        public void SetAgentTransformDestination()
        {
            _navMeshAgent.SetDestination(_transformDestination.position);
        }

        [Button(enabledMode: EButtonEnableMode.Playmode)]
        public void SetAgentVector3Destination()
        {
            _navMeshAgent.SetDestination(_vector3Destination);
        }
    }
}
