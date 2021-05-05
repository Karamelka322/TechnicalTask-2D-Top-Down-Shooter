using UnityEngine;

public class CellHealthSegment : MonoBehaviour
{
    [SerializeField] private GameObject _icon;

    public void ActivCell(bool isActiv)
    {
        _icon.SetActive(isActiv);
    }
}
