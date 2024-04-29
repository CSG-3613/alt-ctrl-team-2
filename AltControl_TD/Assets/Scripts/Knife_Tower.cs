using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Tower : MonoBehaviour
{
    public int Damage;
    public float speed = 50;
    public float RotAngleX = 90;
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
    void Update()
    {
        float rX = Mathf.SmoothStep(0, RotAngleX, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(rX, 0, 0);
    }
}


