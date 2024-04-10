using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _isOccupied = false;
    
    public bool CheckIsOccupied()
    {
        return _isOccupied;
    }

    public void ChangeIsOccupied()
    {
        _isOccupied = !_isOccupied;
    }
}
