using JAM.Shared.Systems.Resource;
using NaughtyAttributes;
using UnityEngine;

namespace JAM.Resources
{
    public class ResourceSystemClient : MonoBehaviour
    {
        [SerializeField] private ResourceSystem _resourceSystem;

        [Header("View")]
        [SerializeField] private bool _useView;
        [SerializeField] private ResourceSystemView _resourceSystemView;


        private void Start()
        {
            if (!TryGetComponent(out _resourceSystem))
            {
                Debug.LogError("No ResourceSystem found in the GameObject", this);
            }
            InitializeResourceSystemView();
        }

        private void InitializeResourceSystemView()
        {
            if (!_useView) { return; }
            _resourceSystemView.UpdateResourceAmount(_resourceSystem.Amount);
            _resourceSystem.AmountChanged.AddListener(_resourceSystemView.UpdateResourceAmount);
        }


        #region Debug
        [Button]
        /// <summary>
        /// Debug method to increase the resource
        /// </summary>
        public void Increase()
        {
            _resourceSystem.IncreaseAmount(1f);
        }

        [Button]
        /// <summary>
        /// Debug method to decrease the resource
        /// </summary>
        public void Decrease()
        {
            _resourceSystem.DecreaseAmount(1f);
        }

        [Button]
        /// <summary>
        /// Debug method to restore resource amount
        /// </summary>
        public void Restore()
        {
            _resourceSystem.RestoreAmount();
        }
        #endregion
    }
}
