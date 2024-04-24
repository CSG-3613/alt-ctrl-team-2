using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyPath _path;
    private float _lastSpawn = 0;
    private float _lastBuff = 0;
    private EnemyState _state;
    private float _enemySpeedModifier = 0;
    private int _enemyHPModifier = 0;
    private GameObject _enemyPrefab;
    [SerializeField]
    public int SpawnDelay;
    public int BuffDelay;
    public float EnemyBaseSpeed = 5;
    public int EnemyBaseHP = 2;
    public float EnemySpeedIncreaseRate;
    public int EnemyHPIncreaseRate;
    public GameObject[] EnemyPrefabList;
    
    public List<Transform> EnemyWayPoints = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Time.realtimeSinceStartup-_lastSpawn;
        Debug.Log(timePassed);

        if (timePassed >= SpawnDelay)
        {
           _enemyPrefab = EnemyPrefabList[RandomizeSelection()];
            Debug.Log("I spawned " + _enemyPrefab.name);
            GameObject Enemy = Instantiate(_enemyPrefab);
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
            _lastSpawn = Time.realtimeSinceStartup;
        }

        timePassed = Time.realtimeSinceStartup - _lastBuff;

        if(timePassed >= BuffDelay)
        {
            _enemyHPModifier += EnemyHPIncreaseRate;
            _enemySpeedModifier += EnemySpeedIncreaseRate;
            _lastBuff = Time.realtimeSinceStartup;
        }
        //Debug.Log("HP mod = " + _enemyHPModifier + ", Speed mod = " + _enemySpeedModifier);
        
    }

    int RandomizeSelection()
    {
        int rng = Random.Range(0,6);
        if(rng <= 2 )
        {
            return 0;
        }
        else if(rng <= 4 ) { return 1; }
        else { return 2; }

    }

}
