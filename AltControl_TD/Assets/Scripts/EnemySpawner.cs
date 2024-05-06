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
    private float _lastSpawnRateUp = 0;
    private EnemyState _state;
    private GameObject _enemyPrefab;
    private bool _hitSpeedCap = false;
    private bool _hitHPCap = false;
    private bool _hitSpawnRateCap = false;
    private float _enemySpeedModifier = 0;
    private int _enemyHPModifier = 0;
    private float _spawnRateModifier = 0;
    private float _baseSpawnRateMemory;
    [SerializeField]
    [Header("Base Values")]
    public float BaseSpawnRate;
    public float EnemyBaseSpeed = 5;
    public int EnemyBaseHP = 2;
    [Header("Delays Until Increase")]
    public int BuffDelay;
    public float SpawnRateIncreaseDelay;
    [Header("Values to Buff By")]
    public float EnemySpeedIncreaseRate;
    public int EnemyHPIncreaseRate;
    public float SpawnRateIncreaseRate;
    [Header("Buff Caps")]
    public float SpeedCap;
    public int HPCap;
    [Tooltip("Note: Spawn Rate caps at a minimum; a lower spawn rate value here will cause enemies to spawn faster.  It's confusing, I know, but I wasn't thinking when I made this and honestly can't be bothered to change it.")]
    public float SpawnRateCap;
    [Header("Enemies")]
    public GameObject[] EnemyPrefabList;
    
    public List<Transform> EnemyWayPoints = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        _baseSpawnRateMemory = BaseSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStates.GetInstance().GameRunning)
        {
            //float startTime = (Time.realtimeSinceStartup - GameStates.GetInstance().GetStartTime());
            float timePassed = Time.realtimeSinceStartup -  _lastSpawn;
            //Debug.Log(timePassed);

            if (timePassed >= BaseSpawnRate)
            {
                _enemyPrefab = EnemyPrefabList[RandomizeSelection()];
                //Debug.Log("I spawned " + _enemyPrefab.name);
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

            if (!_hitHPCap || !_hitSpeedCap)
            {
                if (timePassed >= BuffDelay)
                {
                    if (!_hitHPCap)
                    {
                        if (_enemyHPModifier + EnemyBaseHP >= HPCap)
                        {
                            _hitHPCap = true;
                            _enemyHPModifier = HPCap - EnemyBaseHP;
                        }
                        else
                        {
                            _enemyHPModifier += EnemyHPIncreaseRate;
                        }

                    }
                    if (!_hitSpeedCap)
                    {
                        if (_enemySpeedModifier + EnemyBaseSpeed >= SpeedCap)
                        {
                            _hitSpeedCap = true;
                            _enemySpeedModifier = SpeedCap - EnemyBaseSpeed;
                        }
                        else
                        {
                            _enemySpeedModifier += EnemySpeedIncreaseRate;
                        }
                    }


                    _lastBuff = Time.realtimeSinceStartup;
                }
            }


            timePassed = Time.realtimeSinceStartup - _lastSpawnRateUp;

            if (!_hitSpawnRateCap)
            {
                if (timePassed >= SpawnRateIncreaseDelay)
                {
                    if (BaseSpawnRate - SpawnRateIncreaseRate <= SpawnRateCap)
                    {
                        _hitSpawnRateCap = true;
                        BaseSpawnRate = SpawnRateCap;
                    }
                    else
                    {
                        BaseSpawnRate -= SpawnRateIncreaseRate;
                    }
                    _lastSpawnRateUp = Time.realtimeSinceStartup;
                }

            }

            Debug.Log("HP mod = " + _enemyHPModifier + ", Speed mod = " + _enemySpeedModifier + ", Spawn rate mod = " + _spawnRateModifier);
        }
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
    
    public void Reset()
    {
        Debug.Log("Reseting");
        _enemyHPModifier = 0;
        _enemySpeedModifier = 0;
        _spawnRateModifier = 0;
        BaseSpawnRate = _baseSpawnRateMemory;
        _hitHPCap = false;
        _hitSpawnRateCap = false;
        _hitSpeedCap = false;
    }

}
