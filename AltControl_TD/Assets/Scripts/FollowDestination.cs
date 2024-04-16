/***
 * Author: Stu Dent
 * Date Created: 3-12-24
 * Modified By:
 * Modified Date: 
 * Description: Destiation path for AI navmesh agent
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent _thisAgent;
    // public Transform Desination;
    private EnemyPath _npcPatrolPath;
    [HideInInspector]
    public bool EndOfPath = false;
    [SerializeField]
    private int _patrolPahtIndex = 0;

    private void Awake()
    {
        _thisAgent = GetComponent<NavMeshAgent>();
        _npcPatrolPath = GetComponent<EnemyPath>();
    }//end Awake()



    // Move NPC to next waypoint on path on Update
    void Update()
    {
        
        if(_patrolPahtIndex < _npcPatrolPath.WayPoints.Count)
        {
            int lastIndex = _patrolPahtIndex;
            _patrolPahtIndex = _npcPatrolPath.UpdateDestination(this.transform, _patrolPahtIndex);
            Vector3 NextDestination = _npcPatrolPath.GetDestinationOnPath(this.transform, _patrolPahtIndex);
            if (lastIndex != _patrolPahtIndex)
            {
                _thisAgent.velocity = Vector3.zero;
            }
            _thisAgent.SetDestination(NextDestination);
        }
        else
        {
            EndOfPath = true;
            Debug.Log("end");
        }
        
        
        

    }//end Update()
}
