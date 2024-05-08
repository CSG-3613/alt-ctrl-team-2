using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool OnPath = true;
    public bool destroyOnDeath;

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
            //Debug.Log("I've fallen and I can't get up");
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            
        }
        if (OnPath)
        {
            EndOfPath();
        }
        
    }

    private void EndOfPath()
    {
        if (_enemyFollow.EndOfPath)
        {
            if (_isCooked)
            {
                //Debug.Log("cooked food");
            }
            else
            {
                //Debug.Log("raw food");
                GameStates.GetInstance().SetHP(GameStates.GetInstance().GetHP() - 1);
                //Debug.Log(GameStates.GetInstance().GetHP());
            }

            Destroy(gameObject);
            
        }
    }
}
