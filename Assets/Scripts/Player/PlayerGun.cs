using UnityEngine;

[RequireComponent(typeof(InventoryGuns))]
public class PlayerGun : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;

    private InventoryGuns _inventory;
    private Gun _nowGun;

    private int _numberGun;

    private void Awake()
    {
        _inventory = GetComponent<InventoryGuns>();

        InstallationGun(_inventory.Guns[_numberGun]);
    }

    private void OnEnable()
    {
        _input.ShootGun += OnShootGun;
        _input.ReplaceGun += OnReplaceGun;
    }

    private void OnDisable()
    {
        _input.ShootGun -= OnShootGun;        
        _input.ReplaceGun -= OnReplaceGun;
    }

    private void OnShootGun()
    {
        _nowGun.Shoot(this);
    }

    private void OnReplaceGun()
    {
        _numberGun = _numberGun + 1 == _inventory.Guns.Count ? 0 : _numberGun + 1;
        InstallationGun(_inventory.Guns[_numberGun]);
    }

    private void InstallationGun(Gun gun)
    {
        ClearBackPack();

        _nowGun = gun;
        _nowGun.Spawn(transform);

        void ClearBackPack()
        {
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }
    }
}
