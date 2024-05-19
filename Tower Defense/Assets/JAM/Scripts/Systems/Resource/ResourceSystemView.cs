using TMPro;
using UnityEngine;

namespace JAM
{
    public class ResourceSystemView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI _resourceAmountText;

        [Header("Debug")]
        [SerializeField] private bool _showLogs;


        public void UpdateResourceAmount(float value)
        {
            if (_resourceAmountText == null) { return; }

            _resourceAmountText.text = value.ToString();

            if (_showLogs) { Debug.Log($"value: {value}"); }
        }
    }
}
