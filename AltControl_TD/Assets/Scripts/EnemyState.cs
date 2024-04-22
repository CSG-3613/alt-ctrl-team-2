using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    private FollowDestination _enemyFollow;
    private NavMeshAgent _agent;
    private bool _isCooked = false;
    [SerializeField]
    public int HitPoints = 2;
    public float Speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        _enemyFollow = GetComponent<FollowDestination>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isCooked == false && HitPoints <= 0)
        {
            _isCooked=true;
        }
        EndOfPath();
    }

    private void EndOfPath()
    {
        if (_enemyFollow.EndOfPath)
        {
            if (_isCooked)
            {
                Debug.Log("cooked food");
            }
            else
            {
                Debug.Log("raw food");
            }
            Destroy(gameObject);
            
        }
    }
}
