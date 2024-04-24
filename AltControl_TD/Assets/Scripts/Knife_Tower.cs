using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Tower : MonoBehaviour
{
    public int Damage;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Knife Collisions");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            EnemyState TargetState = other.gameObject.GetComponent<EnemyState>();
            TargetState.HitPoints = TargetState.HitPoints - Damage;

        }
    }
}


