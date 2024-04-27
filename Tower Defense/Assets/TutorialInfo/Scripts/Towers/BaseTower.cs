using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Tower", order = 1)]
    public class BaseTower : ScriptableObject
    {
        [SerializeField] public float Range;
        [SerializeField] public float SecondsToShoot;
        [SerializeField] public Bullet BulletType;
    }
}
