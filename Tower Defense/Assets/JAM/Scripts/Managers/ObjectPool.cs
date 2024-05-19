using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Singleton;

namespace JAM
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int poolSize;
        private List<GameObject> pooledObjects = new List<GameObject>();

        private void InitializePool() 
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        void Start()
        {
            InitializePool();
        }

        public GameObject CallObjectFromPool()
        {
            foreach (GameObject obj in pooledObjects)
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
