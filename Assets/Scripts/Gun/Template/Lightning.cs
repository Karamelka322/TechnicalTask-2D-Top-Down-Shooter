using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Gun/Lightning", fileName = "Lightning", order = 51)]
public class Lightning : Gun, IGun
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Weapon _gunPrefab;
    [SerializeField] private Bullet _bulletTemplate;
    [Space]
    [SerializeField] private float _delayAttack;

    public override AudioClip Sound => _sound;
    public override Sprite Icon => _icon;
    public Weapon GunPrefab => _gunPrefab;
    public Bullet BulletPrefab => _bulletTemplate;

    private Weapon _weapon;
    private Coroutine _coroutine;

    public override void Spawn(Transform folder)
    {
        _weapon = Instantiate(_gunPrefab, folder);
    }

    public override void Shoot(PlayerGun playerGun)
    {
        if (_coroutine != null)
            return;

        _coroutine = playerGun.StartCoroutine(UseGun());

        _weapon.Source.PlayOneShot(_sound);
    }

    IEnumerator UseGun()
    {
        Bullet bullet = Instantiate(_bulletTemplate, null);
        bullet.transform.position = _weapon.GetSpawnPoint;
        bullet.Direction = _weapon.GetDirecion;

        yield return new WaitForSeconds(_delayAttack);

        _coroutine = null;
    }
}
