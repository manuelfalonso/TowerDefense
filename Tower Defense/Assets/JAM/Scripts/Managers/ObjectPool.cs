using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

namespace JAM.Pools
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolSize;
        private List<GameObject> _pooledObjects = new List<GameObject>();

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                GameObject obj = Instantiate(_prefab);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }

        void Start()
        {
            InitializePool();
        }

        public GameObject CallObjectFromPool()
        {
            foreach (GameObject obj in _pooledObjects)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            return null;
        }
    }
}
