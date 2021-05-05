using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGuns : MonoBehaviour
{
    [SerializeField] private List<Gun> _weapons;
    public List<Gun> Guns => _weapons;
}
