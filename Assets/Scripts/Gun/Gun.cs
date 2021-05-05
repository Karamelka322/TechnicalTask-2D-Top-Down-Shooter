using UnityEngine;

public abstract class Gun : ScriptableObject
{
    public abstract AudioClip Sound { get; }
    public abstract Sprite Icon { get; }

    public abstract void Spawn(Transform folder);
    public abstract void Shoot(PlayerGun playerGun);
}
