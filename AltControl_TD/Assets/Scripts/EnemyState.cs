using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private FollowDestination _enemyFollow;

    // Start is called before the first frame update
    void Start()
    {
        _enemyFollow = GetComponent<FollowDestination>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyFollow.EndOfPath)
        {
            Destroy(gameObject);
            Debug.Log("destroy");
        }
    }
}
