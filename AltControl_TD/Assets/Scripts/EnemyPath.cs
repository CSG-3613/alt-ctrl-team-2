using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public List<Transform> WayPoints = new List<Transform>();
    public float WayPointReachingRadius = 1f;
    [SerializeField]
    bool InverseOrder = false;

    //is path valid
    private bool IsPathValid()
    {
        return this.WayPoints.Count > 0;
    }

    //get waypoint pos by index
    public Vector3 GetPositionOfWayPoint(Transform Agent, int WayPointIndex)
    {
        if (WayPointIndex < 0 || WayPointIndex > WayPoints.Count || WayPoints[WayPointIndex] == null)
        {
            return Agent.position;
        }
        return WayPoints[WayPointIndex].position;
    }

    public Vector3 GetDestinationOnPath(Transform Agent, int WayPointIndex)
    {
        if (IsPathValid())
        {
            return GetPositionOfWayPoint(Agent, WayPointIndex);
        }
        else
        {
            return Agent.transform.position;
        }
    }


    public int UpdateDestination(Transform Agent, int WayPointIndex)
    {
        if (IsPathValid())
        {
            if ((Agent.position - GetDestinationOnPath(Agent, WayPointIndex)).magnitude <= WayPointReachingRadius)
            {
                //if (InverseOrder)
                //{
                    /*if (WayPointIndex - 1 < 0)
                    {
                        InverseOrder = false;
                    }
                    else
                    {*/
                        //WayPointIndex -= 1;
                    //}
                //}
                //else
                //{
                    /*if (WayPointIndex + 1 >= WayPoints.Count)
                    {
                        InverseOrder = true;
                    }
                    else
                    {*/
                        WayPointIndex += 1;
                    //}
                //}
                /*else
                {
                    WayPointIndex = WayPointIndex + 1;
                }
                if(WayPointIndex < 0)
                {
                    InverseOrder = false;
                    WayPointIndex = 0;
                }
                if (WayPointIndex >=WayPoints.Count)
                {
                    InverseOrder = true;
                    WayPointIndex = WayPoints.Count - 1;
                }*/



            }

        }
        return WayPointIndex;
    }
}
