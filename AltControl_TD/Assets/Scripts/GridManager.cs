using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private GameObject _currentTower;
    [SerializeField] private GameObject[] _towerArray;

    // Start is called before the first frame update
    void Start()
    {
        _currentTower = _towerArray[0];
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            _currentTower = _towerArray[0];
        }
        if (Input.GetKeyDown("2"))
        {
            _currentTower = _towerArray[1];
        }
        if (Input.GetKeyDown("3"))
        {
            _currentTower = _towerArray[2];
        }
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
                Instantiate(_currentTower, new Vector3(gameObject.transform.position.x, 1.075f, gameObject.transform.position.z), Quaternion.identity);
                tileScript.ChangeIsOccupied();
            }
        }
    }
}
