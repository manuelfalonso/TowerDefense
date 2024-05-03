using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM.Bullets
{
    public class BulletCollisions : MonoBehaviour
    {
        [SerializeField] private BulletBehaviour _bulletBehaviour;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy") 
            {
                _bulletBehaviour.BulletDestroy();
            }
        }
    }
}
