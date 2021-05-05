using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryView : MonoBehaviour
{
    [SerializeField] private InventoryGuns _inventory;
    [SerializeField] private PlayerInput _input;
    [Space]
    [SerializeField] private Image _iconOne;
    [SerializeField] private Image _iconTwo;
    [Space]
    [SerializeField] private Sprite _spriteNullGun;
    [Space]
    [SerializeField] private AudioSource _sound;

    private int _numberGun;

    private void Start()
    {
        FillUiInventory(_inventory.Guns);
    }

    private void OnEnable()
    {
        _input.ReplaceGun += OnReplaceGun;
    }

    private void OnDisable()
    {
        _input.ReplaceGun -= OnReplaceGun;
    }

    private void OnReplaceGun()
    {
        _numberGun = _numberGun + 1 == _inventory.Guns.Count ? 0 : _numberGun + 1;
        
        _iconOne.sprite = _iconTwo.sprite;
        _iconTwo.sprite = _inventory.Guns[_numberGun].Icon;

        _sound.PlayOneShot(_sound.clip);
    }

    private void FillUiInventory(List<Gun> guns)
    {
        try { _iconOne.sprite = guns[0].Icon; } 
        catch { _iconOne.sprite = _spriteNullGun; }        
        
        try { _iconTwo.sprite = guns[1].Icon; } 
        catch { _iconTwo.sprite = _spriteNullGun; }

        _numberGun++;
    }
}
