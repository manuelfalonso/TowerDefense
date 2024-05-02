using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM.Bullets
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/Bullet", order = 1)]
    public class BaseBullet : ScriptableObject
    {
        [SerializeField] public float Speed;
        [SerializeField] public float Damage;
        [SerializeField] public Vector3 Direction;
        [SerializeField] public bool DirectTowardsPlayer;
        [SerializeField] public bool HasAOE;
    }
}