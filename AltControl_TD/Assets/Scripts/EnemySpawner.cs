using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyPath _path;
    [SerializeField]
    public GameObject EnemyPrefab;
    public List<Transform> EnemyWayPoints = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("A");
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Enemy = Instantiate(EnemyPrefab);
        _path = Enemy.GetComponent<EnemyPath>();
        for (int i = 0; i < EnemyWayPoints.Count; i++)
        {
            _path.WayPoints.Add(EnemyWayPoints[i]);
        }
    }

}
