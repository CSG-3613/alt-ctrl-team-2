using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyPath _path;
    private int _timeToSpawn = 0;
    private int _timeToBuff = 0;
    private EnemyState _state;
    private float _enemySpeedModifier = 0;
    private int _enemyHPModifier = 0;
    [SerializeField]
    public int SpawnDelay;
    public int BuffDelay;
    public float EnemyBaseSpeed = 5;
    public int EnemyBaseHP = 2;
    public float EnemySpeedIncreaseRate;
    public int EnemyHPIncreaseRate;
    public GameObject EnemyPrefab;
    public List<Transform> EnemyWayPoints = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeToSpawn++;
        _timeToBuff++;

        if (_timeToSpawn >= SpawnDelay)
        {
            GameObject Enemy = Instantiate(EnemyPrefab);
            Transform EnemyTranform = Enemy.GetComponent<Transform>();
            EnemyTranform.position = gameObject.transform.position;
            _path = Enemy.GetComponent<EnemyPath>();
            _state = Enemy.GetComponent<EnemyState>();
            for (int i = 0; i < EnemyWayPoints.Count; i++)
            {
                _path.WayPoints.Add(EnemyWayPoints[i]);
            }
            _state.Speed = EnemyBaseSpeed + _enemySpeedModifier;
            _state.HitPoints = EnemyBaseHP + _enemyHPModifier;
            _timeToSpawn = 0;
        }

        if(_timeToBuff >= BuffDelay)
        {
            _enemyHPModifier += EnemyHPIncreaseRate;
            _enemySpeedModifier += EnemySpeedIncreaseRate;
            _timeToBuff = 0;
        }
        Debug.Log("HP mod = " + _enemyHPModifier + ", Speed mod = " + _enemySpeedModifier);
        
    }

}
