using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _isOccupied = false;
    [SerializeField] private GameObject _tower;

    private void Awake()
    {
        _tower = this.gameObject;
    }

    private void Update()
    {
        if (_isOccupied)
        {
            if(_tower.transform.position.x != this.gameObject.transform.position.x || _tower.transform.position.z != this.gameObject.transform.position.z)
            {
                ChangeIsOccupied();
                _tower = this.gameObject;
            }
        }
    }

    public bool CheckIsOccupied()
    {
        //Debug.Log(this.gameObject.name + " Was checked");
        return _isOccupied;
        
    }

    public void ChangeTower(GameObject newTower)
    {
        _tower = newTower;
    }

    public void ChangeIsOccupied()
    {
        _isOccupied = !_isOccupied;
    }

}
