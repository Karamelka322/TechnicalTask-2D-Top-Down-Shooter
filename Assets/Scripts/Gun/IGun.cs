using UnityEngine;

interface IGun
{
    Weapon GunPrefab { get; }
    Bullet BulletPrefab { get; }
}
