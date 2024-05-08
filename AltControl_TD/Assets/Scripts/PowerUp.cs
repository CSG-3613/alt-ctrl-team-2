using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject[] tiles;
    void Awake() 
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }
    void Start()
    {
        Invoke("Placement", 3.0f);
    }

    void Placement()
    {
        this.transform.position = tiles[Random.Range(0, tiles.Length)].transform.position;
        Invoke("Placement", Random.Range(3.0f,8.0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower") {
            if(other.gameObject.name == "Tower_Salt")
            {
                other.gameObject.GetComponent<Tower_Script>().fireRate += 5.0f;
            }
            else
            {
                other.gameObject.GetComponent<Grill_Script>().fireRate += 5.0f;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tower")
        {
            if (other.gameObject.name == "Tower_Salt")
            {
                other.gameObject.GetComponent<Tower_Script>().fireRate -= 5.0f;
            }
            else
            {
                other.gameObject.GetComponent<Grill_Script>().fireRate -= 5.0f;
            }
        }
    }

}
