using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private GameObject _currentTower;
    [SerializeField] private GameObject[] _towerArray;
    private bool _isDeleteOn = false;

    void Start()
    {
        _currentTower = _towerArray[0];
    }

    void Update()
    {
        if (Input.GetKeyDown("1")){_currentTower = _towerArray[0]; _isDeleteOn = false; }

        if (Input.GetKeyDown("2")){_currentTower = _towerArray[1]; _isDeleteOn = false; }

        if (Input.GetKeyDown("3")){_currentTower = _towerArray[2]; _isDeleteOn = false; }

        if(Input.GetKeyDown("4")) { _isDeleteOn = true; Debug.Log(_isDeleteOn); }
        
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        
        if (gameObject.tag == "Tile")
        {
            Debug.Log("hit the griddy");
            Tile tileScript = gameObject.GetComponent<Tile>();
            if (!tileScript.CheckIsOccupied())
            {
                _currentTower.transform.position = new Vector3(gameObject.transform.position.x, 1.0f, gameObject.transform.position.z);
               tileScript.ChangeIsOccupied();
               tileScript.ChangeTower(_currentTower);
            }

        }
        else if(gameObject.tag == "Tower")
        {
            if (_isDeleteOn) {
                gameObject.transform.position = new Vector3(0f,-5f,0f);
            }
            
        }
    }
}
